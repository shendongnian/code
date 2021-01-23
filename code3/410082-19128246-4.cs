    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.Threading;
    
    namespace SingleInstanceNP
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                // get application GUID as defined in AssemblyInfo.cs
                string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
    
                // unique id for global mutex - Global prefix means it is global to the machine
                string mutexId = string.Format("Global\\{{{0}}}", appGuid);
    
                using (var mutex = new Mutex(false, mutexId))
                {
                    try
                    {
                        if (!mutex.WaitOne(0, false))
                        {
                            //signal existing app via named pipes
    
                            NamedPipe<string>.Send(NamedPipe<string>.NameTypes.PipeType1, "test");
    
                            Environment.Exit(0);
                        }
                        else
                        {
                            // handle protocol with this instance   
                            Application.Run(new Form1());
    
                        }
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                }
            }
        }
    }
