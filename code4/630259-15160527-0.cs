        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int CompareCallback(IntPtr pvUser, int len1, IntPtr pv1, int len2, IntPtr pv2);
        [DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
        private static extern int sqlite3_create_collation(IntPtr db, byte[] strName, int nType, IntPtr pvUser, CompareCallback func);
        private const int SQLITE_UTF8 = 1;
        private const int SQLITE_UTF16LE = 2;
        private const int SQLITE_UTF16BE = 3;
        private const int SQLITE_UTF16 = 4;    /* Use native byte order */
        private const int SQLITE_ANY = 5;    /* sqlite3_create_function only */
        private const int SQLITE_UTF16_ALIGNED = 8;    /* sqlite3_create_collation only */
        public void Register(IntPtr db)
        {
            if (db == IntPtr.Zero)
                throw new ArgumentNullException("db");
            //create null-terminated UTF8 byte array
            string name = Name;
            var nameLength = System.Text.Encoding.UTF8.GetByteCount(name);
            var nameBytes = new byte[nameLength + 1];
            System.Text.Encoding.UTF8.GetBytes(name, 0, name.Length, nameBytes, 0);
            //register UTF16 comparison
            int result = sqlite3_create_collation(db, nameBytes, SQLITE_UTF16LE, IntPtr.Zero, CompareUTF16);
            if (result != 0)
            {
                string msg = SQLite3.GetErrmsg(db);
                throw SQLiteException.New((SQLite3.Result)result, msg);
            }
            //register UTF8 comparison
            result = sqlite3_create_collation(db, nameBytes, SQLITE_UTF8, IntPtr.Zero, CompareUTF8);
            if (result != 0)
            {
                string msg = SQLite3.GetErrmsg(db);
                throw SQLiteException.New((SQLite3.Result)result, msg);
            }
        }
        private string GetUTF8String(IntPtr ptr, int len)
        {
            if (len == 0 || ptr == IntPtr.Zero)
                return string.Empty;
            if (len == -1)
            {
                do
                {
                    len++;
                }
                while (Marshal.ReadByte(ptr, len) != 0);
            }
            byte[] array = new byte[len];
            Marshal.Copy(ptr, array, 0, len);
            return Encoding.UTF8.GetString(array, 0, len);
        }
        private string GetUTF16String(IntPtr ptr, int len)
        {
            if (len == 0 || ptr == IntPtr.Zero)
                return string.Empty;
            if (len == -1)
            {
                return Marshal.PtrToStringUni(ptr);
            }
            return Marshal.PtrToStringUni(ptr, len / 2);
        }
        internal int CompareUTF8(IntPtr ptr, int len1, IntPtr ptr1, int len2, IntPtr ptr2)
        {
            return Compare(GetUTF8String(ptr1, len1), GetUTF8String(ptr2, len2));
        }
        internal int CompareUTF16(IntPtr ptr, int len1, IntPtr ptr1, int len2, IntPtr ptr2)
        {
            return Compare(GetUTF16String(ptr1, len1), GetUTF16String(ptr2, len2));
        }
