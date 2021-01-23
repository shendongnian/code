    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Reflection;
     
    namespace ConsoleApplication1
    {
     
        class ControlChecker
        {
            #region GLOBAL VARS
            private static readonly Mutex mutex = new Mutex(true, Assembly.GetExecutingAssembly().GetName().CodeBase);
            private static bool _userRequestExit = false;
            private static bool _doIStop = false;
            static HandlerRoutine consoleHandler;
            #endregion
     
            [DllImport("Kernel32")]
            public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
     
            // A delegate type to be used as the handler routine for SetConsoleCtrlHandler.
            public delegate bool HandlerRoutine(CtrlTypes CtrlType);
     
            // An enumerated type for the control messages sent to the handler routine.
            public enum CtrlTypes
            {
                CTRL_C_EVENT = 0,
                CTRL_BREAK_EVENT,
                CTRL_CLOSE_EVENT,
                CTRL_LOGOFF_EVENT = 5,
                CTRL_SHUTDOWN_EVENT
            }
     
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ctrlType"></param>
            /// <returns></returns>
            private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
            {
                // Put your own handler here
                switch (ctrlType)
                {
                    case CtrlTypes.CTRL_C_EVENT:
                        _userRequestExit = true;
                        Console.WriteLine("CTRL+C received, shutting down");
                        break;
     
                    case CtrlTypes.CTRL_BREAK_EVENT:
                        _userRequestExit = true;
                        Console.WriteLine("CTRL+BREAK received, shutting down");
                        break;
     
                    case CtrlTypes.CTRL_CLOSE_EVENT:
                        _userRequestExit = true;
                        Console.WriteLine("Program being closed, shutting down");
                        break;
     
                    case CtrlTypes.CTRL_LOGOFF_EVENT:
                    case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                        _userRequestExit = true;
                        Console.WriteLine("User is logging off!, shutting down");
                        break;
                }
     
                return true;
            }
     
            /// <summary>
            /// Main entry point
            /// </summary>
            /// <param name="args"></param>
            /// <returns></returns>        
            static int Main(string[] args)
            {
                try
                {
                    //make sure we only have one....
                    if (!mutex.WaitOne(TimeSpan.Zero, true))
                    {
                        Console.WriteLine("Another instance already running");
                        Thread.Sleep(5000);
                        return 1;
                    }
     
                    //save a reference so it does not get GC'd
                    consoleHandler = new HandlerRoutine(ConsoleCtrlCheck);
     
                    //set our handler here that will trap exit
                    SetConsoleCtrlHandler(consoleHandler, true);
     
                    DoMyTask();
     
                    return 0;
                }
                catch (Exception x)
                {
                    Console.WriteLine("Main Error [{0}]", x.Message);
                    return -1;
                }
            }
     
            
     
            /// <summary>
            /// Run the export
            /// </summary>
            /// <param name="pAuthority"></param>
            /// <returns></returns>
            private static void DoMyTask()
            {
                //execcute until we have no more records to process
                while (!_doIStop)
                {
                    //did user request exit?
                    if (_userRequestExit)
                    {
                        _doIStop = true;    //set flag to exit loop.  Other conditions could cause this too, which is why we use a seperate variable
                        Console.WriteLine("Shutting down, user requested exit");
                        break;
                    }
     
                    //do some other stuff here
                    Console.WriteLine(String.Format("{0}, no exit requested yet...", DateTime.Now));
                    //sleep 1 second
                    Thread.Sleep(1000);    
                }
            }
        }
    }
