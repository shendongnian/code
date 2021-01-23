    public static extern [MarshalAs(UnmanagedType.LPStr)]string Ololo(
        [MarshalAs(UnmanagedType.LPStr)]string arg,
        ref int n3
    );
    static void Main(string[] args)
    {
        string n1 = "ololo";
        Int32 n3 = 0;
        string n4 = Ololo(chars, ref n3);
        Console.WriteLine(n4);
    }
