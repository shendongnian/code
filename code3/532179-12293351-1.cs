    using System;
    using Microsoft.Win32;
    // Based on: https://stackoverflow.com/a/604042/700926
    namespace WinLockMonitor
    {
        class Program
        {
            static void Main(string[] args)
            {
                Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
                Console.ReadLine();
            }
            static void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
            {
                if (e.Reason == SessionSwitchReason.SessionLock)
                {
                    //I left my desk
                    Console.WriteLine("I left my desk");
                }
                else if (e.Reason == SessionSwitchReason.SessionUnlock)
                {
                    //I returned to my desk
                    Console.WriteLine("I returned to my desk");
                }
            }
        }
    }
