    class Program
    {
        const int blockLength = 256;
        /// <summary>
        /// Method that simulates your C++ Foo() function
        /// </summary>
        /// <param name="output"></param>
        static void Foo(ref IntPtr output)
        {
            const int numberOfStrings = 4;
            byte[] block = new byte[blockLength];
            IntPtr dest = output = Marshal.AllocHGlobal((numberOfStrings * blockLength) + 1);
            for (int i = 0; i < numberOfStrings; i++)
            {
                byte[] source = Encoding.UTF8.GetBytes("Test " + i);
                Array.Clear(block, 0, blockLength);
                source.CopyTo(block, 0);
                Marshal.Copy(block, 0, dest, blockLength);
                dest = new IntPtr(dest.ToInt64() + blockLength);
            }
            Marshal.WriteByte(dest, 0); // terminate
        }
        /// <summary>
        /// Method that calls the simulated C++ Foo() and yields each string
        /// </summary>
        /// <returns></returns>
        static IEnumerable<string> FooCaller()
        {
            IntPtr ptr = IntPtr.Zero;
            Foo(ref ptr);
            while (Marshal.ReadByte(ptr) != 0)
            {
                yield return Marshal.PtrToStringAnsi(ptr, blockLength);
                ptr = new IntPtr(ptr.ToInt64() + blockLength);
            }
        }
        static void Main(string[] args)
        {
            foreach (string fn in FooCaller())
            {
                Debug.Print(fn);
            }
        }
    }
