    public unsafe static void Foo(char*[] input)
    {
        foreach(var cptr in input)
        {
            IntPtr ptr = new IntPtr(cptr);
            char[] output = new char[5]; //NOTE: Size is fixed
            Marshal.Copy(ptr, output, 0, output.Length);
            Console.WriteLine(new string(output));
        }
    }
