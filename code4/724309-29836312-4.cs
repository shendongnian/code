    public class Adam_Robinson
    {
        private static T BytesToStruct<T>(byte[] rawData) where T : struct
        {
            T result = default(T);
            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            try
            {
                IntPtr rawDataPtr = handle.AddrOfPinnedObject();
                result = (T)Marshal.PtrToStructure(rawDataPtr, typeof(T));
            }
            finally
            {
                handle.Free();
            }
            return result;
        }
        /// <summary>
        /// no Copy. no unsafe. Gets a GCHandle to the memory via Alloc
        /// </summary>
        /// <typeparam name="selectedT"></typeparam>
        /// <param name="structure"></param>
        /// <returns></returns>
        public static byte[] StructToBytes<T>(T structure) where T : struct
        {
            int size = Marshal.SizeOf(structure);
            byte[] rawData = new byte[size];
            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            try
            {
                IntPtr rawDataPtr = handle.AddrOfPinnedObject();
                Marshal.StructureToPtr(structure, rawDataPtr, false);
            }
            finally
            {
                handle.Free();
            }
            return rawData;
        }
    }
