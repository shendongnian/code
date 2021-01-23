    class Program
    {
        static void Main(string[] args)
        {
            char[] TNameFile = { 'H', 'e', 'l', 'l', 'o' };
            var result = Foo(TNameFile);
            string str = new string(result);
            Console.WriteLine(str); //prints Hello
        }
        internal unsafe static char[] Foo(char[] input)
        {
            //managed char[] to fixed char*
            char* src;
            fixed (char* cptr = input)
            {
                src = (char*)cptr;
            }
            char** ptrToPtr = &src;
            char*** ptrToPtrToPtr = &ptrToPtr;
            //char* back to managed char[]
            IntPtr ptr = new IntPtr(**ptrToPtrToPtr);
            char[] output = new char[input.Length];
            Marshal.Copy(ptr, output, 0, input.Length);
            return output;
        }
    }
