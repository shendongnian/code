        [DllImport("pfxlibn.dll")]
        public static extern Int32 PclOpen(Int32 iHandle, String sName, Int32 iIndex);
        [DllImport("pfxlibn.dll")]
        public static extern Int32 PclClear(Int32 iHandle);
        [DllImport("pfxlibn.dll")]
        public static extern Int32 PclPutField(Int32 iHandle, Int32 iFieldNum, String sData);
        [DllImport("pfxlibn.dll")]
        public static extern Int32 PclFind(Int32 iHandle, Int32 iRelOp, Int32 iIndex);
        [DllImport("pfxlibn.dll")]
        public static extern Int32 PclGetFieldLen(Int32 iHandle, Int32 iField, out int length);
            error = CLib.PclOpen(_handle, path, 0);
            error = CLib.PclClear(_handle);
            error = CLib.PclPutField(_handle, 0, "10");  //searching for recnum 10
            error = CLib.PclFind(_handle, 1, 0);  // 0 = recnum index
            error = CLib.PclGetFieldLen(_handle, iField, out flenght);
            StringBuilder data = new StringBuilder(flenght);
            CLib.PclGetField(_handle, iField, data);
            if (error == 0)
            {
                return data.ToString();  
            }
