    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using Microsoft.Win32;
    
    namespace WindowsApplication
    {
        static class Program
        {
            /*
        DEMO CODE ONLY: In general, this approach calls for re-thinking 
        your architecture!
        There are 4 possible ways this can run:
        1) User starts application from existing cmd window, and runs in GUI mode
        2) User double clicks to start application, and runs in GUI mode
        3) User starts applicaiton from existing cmd window, and runs in command mode
        4) User double clicks to start application, and runs in command mode.
    
        To run in console mode, start a cmd shell and enter:
            c:\path\to\Debug\dir\WindowsApplication.exe console
            To run in gui mode,  EITHER just double click the exe, OR start it from the cmd prompt with:
            c:\path\to\Debug\dir\WindowsApplication.exe (or pass the "gui" argument).
            To start in command mode from a double click, change the default below to "console".
        In practice, I'm not even sure how the console vs gui mode distinction would be made from a
        double click...
            string mode = args.Length > 0 ? args[0] : "console"; //default to console
        */
    
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool AllocConsole();
    
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool FreeConsole();
    
            [DllImport("kernel32", SetLastError = true)]
            static extern bool AttachConsole(int dwProcessId);
    
            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
    
            [STAThread]
            static void Main(string[] args)
            {
                //TODO: better handling of command args, (handle help (--help /?) etc.)
                string mode = args.Length > 0 ? args[0] : "gui"; //default to gui
    
                if (mode == "gui")
                {
                    MessageBox.Show("Welcome to GUI mode");
    
                    Application.EnableVisualStyles();
    
                    Application.SetCompatibleTextRenderingDefault(false);
    
                    Application.Run(new Form1());
                }
                else if (mode == "console")
                {
    
                    //Get a pointer to the forground window.  The idea here is that
                    //IF the user is starting our application from an existing console
                    //shell, that shell will be the uppermost window.  We'll get it
                    //and attach to it
                    IntPtr ptr = GetForegroundWindow();
    
                    int  u;
    
                    GetWindowThreadProcessId(ptr, out u);
    
                    Process process = Process.GetProcessById(u);
    
                    if (process.ProcessName == "cmd" )    //Is the uppermost window a cmd process?
                    {
                        AttachConsole(process.Id);
                       
                        //we have a console to attach to ..
                        Console.WriteLine("hello. It looks like you started me from an existing console.");
                    }
                    else
                    {
                        //no console AND we're in console mode ... create a new console.
    
                        AllocConsole();
    
                        Console.WriteLine(@"hello. It looks like you double clicked me to start
                       AND you want console mode.  Here's a new console.");
                        Console.WriteLine("press any key to continue ...");
                        Console.ReadLine();       
                    }
    
                    FreeConsole();
                }
            }
        }
    }
