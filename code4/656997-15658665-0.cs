    using System.Threading;
    
    namespace ConsoleApp1
    {
        class MyThread
        {
            static Semaphore sem = new Semaphore(2, 2);
        }
    
        class Program
        {
            static void Main(string[] args) { }
        }
    }
