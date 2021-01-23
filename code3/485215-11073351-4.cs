    public static MyGlobals
    {
        private static readonly Lazy<int> _processBase = new Lazy<int>(() => GetProcessBase("MyProcessName"));
    
        // I don't recommend using the word Base, but OK...
        public static int Base { get { return _processBase.Value; } }
        private static int GetProcessBase(string processName)
        {
            int b = 0;
            Process[] p = Process.GetProcessesByName(processName);
            if(p != null && p.Length > 0)
            {
                b = p[0].MainModule.BaseAddress.ToInt32();
            }
            return b;
        }
    }
