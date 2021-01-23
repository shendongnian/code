    static void Main(string[] args)
    {
        var dict = new MyDictionary<int, string>(x => string.Format("Automatically created Value for key {0}", x));
        dict[1] = "Value for key 1";
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(dict[i]);
        }
        Console.Read();
    }
