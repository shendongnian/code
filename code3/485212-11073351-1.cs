    private static readonly Lazy<int> _processBase = new Lazy<int>(() => GetProcessBase("MyProcessName"));
    
    private static int GetProcessBase(string processName)
    {
        int b = 0;
        Process[] p = Process.GetProcessesByName(processName);
        if(p != null && p.Length > 0)
        {
            b = MainModule.BaseAddress.ToInt32();
        }
        return b;
    }
    
    private void timer1_Tick(object sender, EventArgs e) 
    { 
        if(_processBase.Value > 0)
        {
             //lots of other code blocks 
        }
    } 
