    class Program
    {
        private struct V3
        {
            public float x;
            public float y;
            public float z;
        }
        private static unsafe long GetDistance()
        {
            var array = new V3[2];
            fixed (V3* pointerOne = &array[0])
            fixed (V3* pointerTwo = &array[1])
                return ((byte*)pointerTwo - (byte*)pointerOne);
        }
        unsafe static void Main()
        {
            Console.WriteLine(GetDistance());
            Console.WriteLine(sizeof(IntPtr));
        }
    }
