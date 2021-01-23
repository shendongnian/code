    using System.Runtime.InteropServices;
    // Unmanaged function from user32.dll    
    [DllImport("user32.dll")]    
    static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
    // Struct we'll need to pass to the function    
    internal struct LASTINPUTINFO    
    {    
        public uint cbSize;    
        public uint dwTime;    
    }
    private void tmrIdle_Tick(object sender, EventArgs e)    
    {    
        // Get the system uptime    
        int systemUptime = Environment.TickCount;    
        // The tick at which the last input was recorded    
        int LastInputTicks = 0;    
        // The number of ticks that passed since last input    
        int IdleTicks = 0;            
        // Set the struct    
        LASTINPUTINFO LastInputInfo = new LASTINPUTINFO();    
        LastInputInfo.cbSize = (uint)Marshal.SizeOf(LastInputInfo);    
        LastInputInfo.dwTime = 0;       
    
        // If we have a value from the function    
        if (GetLastInputInfo(ref LastInputInfo))    
        {    
            // Get the number of ticks at the point when the last activity was seen    
            LastInputTicks = (int)LastInputInfo.dwTime;    
            // Number of idle ticks = system uptime ticks - number of ticks at last input    
            IdleTicks = systemUptime - LastInputTicks;    
        }        
    
        // Set the labels; divide by 1000 to transform the milliseconds to seconds    
        lblSystemUptime.Text = Convert.ToString(systemUptime / 1000) + " seconds";    
        lblIdleTime.Text = Convert.ToString(IdleTicks / 1000) + " seconds";    
        lblLastInput.Text = "At second " + Convert.ToString(LastInputTicks / 1000);    
    }
