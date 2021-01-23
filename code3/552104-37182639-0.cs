    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Excel = Microsoft.Office.Interop.Excel;
    using Office = Microsoft.Office.Core;
    using Microsoft.Office.Tools.Excel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace ExcelAddIn_TestExcelWindowActivation
    {
        public partial class ThisAddIn
        {
            [DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
            public static extern IntPtr GetForegroundWindow();
    
            private IntPtr _excelWindowHandle = IntPtr.Zero;
            private IntPtr _lastForegroundWindowHandle = IntPtr.Zero;
            private Timer _timerForegroundWindowObserver = null;
    
            private void InternalStartup()
            {
                this.Startup += new System.EventHandler(ThisAddIn_Startup);
                this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
    
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                //Get excel handle
                _excelWindowHandle = new IntPtr(Globals.ThisAddIn.Application.Hwnd);
    
                //Initialize and start the timer
                _timerForegroundWindowObserver = new Timer();
                _timerForegroundWindowObserver.Interval = 1000; //ms
                _timerForegroundWindowObserver.Tick +=new EventHandler(_timerForegroundWindowObserver_Tick);
                _timerForegroundWindowObserver.Start();
    
                Debug.Print("ThisAddIn_Startup completed.");
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
                //Stop and delete the timer
                _timerForegroundWindowObserver.Stop();
                _timerForegroundWindowObserver = null;
            }
    
            private void _timerForegroundWindowObserver_Tick(object sender, EventArgs e)
            {
                var foregroundWindowHandle = GetForegroundWindow();
                
                //Remember the last foreground window and exit if there were no changes...
                if (foregroundWindowHandle == _lastForegroundWindowHandle) return;
                _lastForegroundWindowHandle = foregroundWindowHandle;
    
                //When Excel is activated: Give info...
                if (foregroundWindowHandle == _excelWindowHandle)
                {
                    Debug.Print("Excel window is activated yet.");
                }
            }
        }
    }
