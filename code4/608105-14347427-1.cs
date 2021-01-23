    public static class CopyDataHelper
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct COPYDATASTRUCT
        {
            private Int32 _dwData;
            private Int32 _cbData;
            private IntPtr _lpData;
    
            public Int32 DataId
            {
                get { return _dwData; }
                set { _dwData = value; }
            }
    
            public Int32 DataSize
            {
                get { return _cbData; }
            }
    
            public IntPtr Data
            {
                get { return _lpData; }
            }
    
            public T GetData<T>() where T : struct
            {
                return (T)Marshal.PtrToStructure(_lpData, typeof(T));
            }
            public void SetData<T>(T data) where T : struct
            {
                Int32 size = Marshal.SizeOf(typeof(T));
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(data, ptr, true);
                _cbData = size;
                _lpData = ptr;
            }
        }
    
        [DllImport("User32.dll", CharSet=CharSet.Unicode, ExactSpelling=true, SetLastError=true)]
        [return:  MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SendMessage([In] IntPtr hWnd, [In] UInt32 msg, [In] IntPtr wParam, [In, Out] ref COPYDATASTRUCT lParam);
    
        public const Int32 WM_COPYDATA = 0x004A;
    
        public static Boolean Send<T>(IntPtr fromHwnd, IntPtr toHwnd, Int32 dataId, T data) where T : struct
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
                throw new ArgumentException("This is not a WM_COPYDATA message!");
            return (COPYDATASTRUCT)msg.GetLParam(typeof(COPYDATASTRUCT));
        }   
    }
    // Override
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
