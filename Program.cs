using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegateandevent
{
    class Program
    {
        //PURE Publisher Subscriber Machanism
        static void Main(string[] args)
        {
            Mylongtask x = new Mylongtask();
            x.sender += reciver;
            x.sender += reciver1;
            x.sender += reciver2;
            //x.sender = null;
            Thread t = new Thread(new ThreadStart(x.Longtaskmethod));
            t.Start();
            Console.WriteLine("Program.cs");
            Console.ReadLine();
        }

       public static void reciver(int i)
        {
            Console.WriteLine("Reciver "+i);
        }
        public static void reciver1(int i)
        {
            Console.WriteLine("Reciver1 " + i);
        }
        public static void reciver2(int i)
        {
            Console.WriteLine("Reciver2 " + i);
        }
    }

    class Mylongtask
    {
        public delegate void Sender(int i);//declaraction of deligate
        public event Sender sender = null;

        public void Longtaskmethod()
        {
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(5000);
                sender(i);
            }
            
        
        }
    
    }
}
