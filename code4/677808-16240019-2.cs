    public static void Main(string[] args)
    {
        var funs = new Action<string>[5];
        int j;
        for (int i = 0; i < 5; i++)
        {
            j = i;
            {
                funs[j] = x => Console.WriteLine(j);
            }
        }
        funs[2]("foo");
    }
