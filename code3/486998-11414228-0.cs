    class LibWrapper
    {
        [DllImport("CPPDLL.dll")]
        public static extern IntPtr CreateObject();
        [DllImport("CPPDLL.dll")]
        public static extern void SetObjectData(IntPtr ptrObj, StringBuilder strInput);
        [DllImport("CPPDLL.dll")]
        public static extern StringBuilder GetObjectData(IntPtr ptrObj);
        [DllImport("CPPDLL.dll")]
        public static extern void DisposeObject(IntPtr ptrObj);
    }
    public static void CallDLL()
    {
        try
        {
            IntPtr ptrObj = Marshal.AllocHGlobal(4);
            ptrObj = LibWrapper.CreateObject();
            StringBuilder strInput = new StringBuilder();
            strInput.Append("DLL Test");
            MessageBox.Show("Before DLL Call: " + strInput.ToString());
            LibWrapper.SetObjectData(ptrObj, strInput);
            StringBuilder strOutput = new StringBuilder();
            strOutput = LibWrapper.GetObjectData(ptrObj);
            MessageBox.Show("After DLL Call: " + strOutput.ToString());
            LibWrapper.DisposeObject(ptrObj);
        }
        ...
    }
