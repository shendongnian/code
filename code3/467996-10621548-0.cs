    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                SetConsoleCtrlHandler(ConsoleCtrlCheck, true);
                Console.WriteLine("CTRL+C,CTRL+BREAK or suppress the application to exit");
                while (!isclosing)
                {
                    Thread.Sleep(1000);
                }
            }
            private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
            {
                // Put your own handling here:
                switch (ctrlType)
                {
                    case CtrlTypes.CTRL_C_EVENT:
                        isclosing = true;
                        Console.WriteLine("CTRL+C received!");
                        break;
                    case CtrlTypes.CTRL_BREAK_EVENT:
                        isclosing = true;
                        Console.WriteLine("CTRL+BREAK received!");
                        break;
                    case CtrlTypes.CTRL_CLOSE_EVENT:
                        isclosing = true;
                        Console.WriteLine("Program being closed!");
                        MessageBox.Show("AHA!");
                        break;
                    case CtrlTypes.CTRL_LOGOFF_EVENT:
                    case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                        isclosing = true;
                        Console.WriteLine("User is logging off!");
                        break;
                }
                return true;
            }
            #region unmanaged
            // Declare the SetConsoleCtrlHandler function as external and receiving a delegate.
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
            #endregion
            private static bool isclosing;
        }
    }
