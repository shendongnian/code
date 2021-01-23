    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Threading;
    namespace HangApp
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                Runner r = new Runner();
            }
            class Runner
            {
                internal Runner()
                {
                    _start = DateTime.Now;
                    Thread t = new Thread(ThreadStart);
                    t.Start();
                }
                DateTime _start;
                void ThreadStart()
                {
                    while (true)
                    {
                        //  some stuff to do
                        if (ExitConditionMet())
                        {
                            break;
                        }
                    }
                }
                bool ExitConditionMet()
                {
                    //  will run the app for 5 seconds after main form was closed
                    return (DateTime.Now - _start).TotalSeconds > 5;
                }
            }
        }
    }
