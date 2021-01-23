    public static void Main(string[] args)
    {
        var funs = new Action<string>[5];
        for (int i = 0; i < 5; i++)
        {
            int j = i;
            {
                funs[j] = x => Console.WriteLine(j);
            }
        }
        funs[2]("foo"); // prints 2
    }
