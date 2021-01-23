    using System;
    using System.Threading;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program pr = new Program();
                pr.ThreadDeclaration();
                Console.Read();
            }
            public void ThreadDeclaration()
            {
                int timeInterval = 5000;
                for (int i=1; i<3; i++)
                {
                    int time = timeInterval * i;
                    ThreadStart starter = () => PasParamsToThrdFunc(time);
                    var thread = new Thread(starter) {Name = i.ToString()};
                    thread.Start();
                }
            }
            public void PasParamsToThrdFunc(int waitTime)
            {
                Thread.Sleep(waitTime);
                Console.WriteLine("" + waitTime + " seconds completed and method is called for thread" + Thread.CurrentThread.Name);
            }
        }
    }                                                                                            
