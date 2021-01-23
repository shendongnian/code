        [Serializable]
        public struct newLeads
        {
            public string id;
            public string first_name;
            public string last_name;
        }
        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        public static byte[] ToByteArray(newLeads value)
        {
            int length = Marshal.SizeOf(typeof(newLeads));
            var result = new byte[length];
            IntPtr sourcePtr = Marshal.AllocHGlobal(length);
            Marshal.StructureToPtr(value, sourcePtr, false);
            Marshal.Copy(sourcePtr, result, 0, length);
            Marshal.FreeHGlobal(sourcePtr);
            return result;
        }
