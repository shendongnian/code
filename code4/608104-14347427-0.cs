    public static class CopyDataHelper
    {
    
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            private int _dwData;
            private int _cbData;
            private IntPtr _lpData;
    
            public int DataId
            {
                get { return _dwData; }
                set { _dwData = value; }
            }
    
            public int DataSize
            {
                get { return _cbData; }
            }
    
            public IntPtr Data
            {
                get { return _lpData; }
            }
    
            public void SetData<T>(T data) where T : struct
            {
                int size = Marshal.SizeOf(typeof(T));
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(data, ptr, true);
                _lpData = ptr;
                _cbData = size;
            }
    
            public T GetData<T>() where T : struct
            {
                return (T)Marshal.PtrToStructure(_lpData, typeof(T));
            }
        }
    
        [DllImport("User32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
    
        public const int WM_COPYDATA = 0x004A;
    
        public static bool Send<T>(IntPtr fromHwnd, IntPtr toHwnd, int dataId, T data) where T : struct
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                COPYDATASTRUCT cds = new COPYDATASTRUCT();
                cds.DataId = dataId;
                cds.SetData(data);
                return SendMessage(toHwnd, WM_COPYDATA, fromHwnd, ref cds);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptr);
            }
        }
    
        public static COPYDATASTRUCT Receive(Message msg)
        {
            if (msg.Msg != WM_COPYDATA)
                throw new ArgumentException("This is not a WM_COPYDATA message");
            COPYDATASTRUCT cds = (COPYDATASTRUCT)msg.GetLParam(typeof(COPYDATASTRUCT));
            return cds;
        }
    
    }
    protected override void WndProc(ref Message msg)
    {
        if (msg.Msg == CopyDataHelper.WM_COPYDATA)
        {
            CopyDataHelper.COPYDATASTRUCT cds = CopyDataHelper.Receive(msg);
            if (cds.DataId == myDataId)
            {
                MyData data = cds.GetData<MyData>();
                msg.Result = DoSomething(data);
                return;
            }
        }
        base.WndProc(ref msg);
    }
