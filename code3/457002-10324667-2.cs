    class Program
    {
        private const int SIZE = 128;
        unsafe public struct Frame
        {
            public uint Identifier;
            public fixed byte Name[SIZE];
        }
        
        [DllImport("PinvokeTest2.DLL", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern Frame GetFrame(int index);
        static unsafe string GetNameFromFrame(Frame frame)
        {
            //Option 1: Use if the string in the buffer is always null terminated
            //return Marshal.PtrToStringAnsi(new IntPtr(frame.Name));
            //Option 2: Use if the string might not be null terminated for any reason,
            //like if were 128 non-null characters, or the buffer has corrupt data.
            return Marshal.PtrToStringAnsi(new IntPtr(frame.Name), SIZE).Split('\0')[0];
        }
        static void Main()
        {
            Frame a = GetFrame(0);
            Console.WriteLine(GetNameFromFrame(a));
        }
    }
