    /// <summary>
    /// http://stackoverflow.com/questions/2623761/marshal-ptrtostructure-and-back-again-and-generic-solution-for-endianness-swap
    /// </summary>
    public class DanB
    {
        /// <summary>
        /// uses Marshal.Copy! Not run in unsafe. Uses AllocHGlobal to get new memory and copies.
        /// </summary>
        public static byte[] GetBytes<T>(T structure) where T : struct
        {
            var size = Marshal.SizeOf(structure); //or Marshal.SizeOf<selectedT>(); in .net 4.5.1
            byte[] rawData = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structure, ptr, true);
            Marshal.Copy(ptr, rawData, 0, size);
            Marshal.FreeHGlobal(ptr);
            return rawData;
        }
        public static T FromBytes<T>(byte[] bytes) where T : struct
        {
            var structure = new T();
            int size = Marshal.SizeOf(structure);  //or Marshal.SizeOf<selectedT>(); in .net 4.5.1
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, ptr, size);
            structure = (T)Marshal.PtrToStructure(ptr, structure.GetType());
            Marshal.FreeHGlobal(ptr);
            return structure;
        }
    }
