    public static void Main(string[] args)
    {
        var a = new s { i = 1, j = 2 };
        var sPtr = (byte*)&a;
        var size = sizeof(s);
        var mem = new byte[size];
        fixed (byte* memPtr = mem)
        {
            for (int i = 0; i < size; i++)
            {
                *(memPtr + i) = *sPtr++;
            }
        }
        File.WriteAllBytes("A:\\file.txt", mem);
    }
    struct s
    {
        internal int i;
        internal int j;
    }
