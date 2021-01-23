    public static void Main(string[] args)
    {
        var funs = new Action<string>[5];
        for (int i = 0; i < 5; i++)
            D(i, funs);
        funs[2]("foo"); // prints 2
    }
       
    static void D(int i, Action<string>[] funs)
    {
        int j = i;
        {
            funs[j] = x => Console.WriteLine(j);
        }
    }
