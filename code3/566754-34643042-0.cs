        protected override void OnLoad(EventArgs e)
        {
        /* Check if we are in idle mode - No mouse movement for 2 minutes */
        System.Windows.Forms.Timer CheckIdleTimer = new                    System.Windows.Forms.Timer();
        CheckIdleTimer.Interval = 120000;
        CheckIdleTimer.Tick += new EventHandler(CheckIdleTimer_Tick);
        CheckIdleTimer.Start();
        }
        private void CheckIdleTimer_Tick(object sender, EventArgs e)
        {
        uint x = IdleTimeFinder.GetIdleTime();
        if (x > 120000) {
             //...do something
        }
        }
    
    
        public class IdleTimeFinder
        {
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
    
        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();
    
        public static uint GetIdleTime()
        {
        LASTINPUTINFO lastInPut = new LASTINPUTINFO();
        lastInPut.cbSize     (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
        GetLastInputInfo(ref lastInPut);
        return ((uint)Environment.TickCount - lastInPut.dwTime);
        }
            
       public static long GetLastInputTime()
       {
        LASTINPUTINFO lastInPut = new LASTINPUTINFO();
        lastInPut.cbSize                (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
        if (!GetLastInputInfo(ref lastInPut))
        {
        throw new Exception(GetLastError().ToString());
        }
        return lastInPut.dwTime;
        }
        }
     internal struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }
