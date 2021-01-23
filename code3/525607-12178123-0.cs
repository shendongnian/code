    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace WindowsMonitor
    {
        public class ActiveWindowChangedEventArgs : EventArgs
        {
            public IntPtr CurrentActiveWindow { get; private set; }
            public IntPtr LastActiveWindow { get; private set; }
            public ActiveWindowChangedEventArgs(IntPtr lastActiveWindow, IntPtr currentActiveWindow)
            {
                this.LastActiveWindow = lastActiveWindow;
                this.CurrentActiveWindow = currentActiveWindow;
            }
        }
        public delegate void ActiveWindowChangedEventHandler(object sender, ActiveWindowChangedEventArgs e);
        public class ActiveWindowMonitor
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
            private Timer monitorTimer;
            public IntPtr ActiveWindow { get; private set; }
            public event ActiveWindowChangedEventHandler ActiveWindowChanged;
            public ActiveWindowMonitor()
            {
                this.monitorTimer = new Timer();
                this.monitorTimer.Tick += new EventHandler(monitorTimer_Tick);
                this.monitorTimer.Interval = 10;
                this.monitorTimer.Start();
            }
            private void monitorTimer_Tick(object sender, EventArgs e)
            {
                CheckActiveWindow();
            }
            private void CheckActiveWindow()
            {
                IntPtr currentActiveWindow = GetForegroundWindow();
                if (this.ActiveWindow != currentActiveWindow)
                {
                    IntPtr lastActiveWindow = this.ActiveWindow;
                    this.ActiveWindow = currentActiveWindow;
    
                    OnActiveWindowChanged(lastActiveWindow, this.ActiveWindow);
                }
            }
            protected virtual void OnActiveWindowChanged(IntPtr lastActiveWindow, IntPtr currentActiveWindow)
            {
                ActiveWindowChangedEventHandler temp = ActiveWindowChanged;
                if (temp != null)
                {
                    temp.Invoke(this, new ActiveWindowChangedEventArgs(lastActiveWindow, currentActiveWindow));
                }
            }
        }
    }
