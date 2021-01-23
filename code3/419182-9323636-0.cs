    static void Main(string[] args)
    {
        object obj = null;
        double d = Convert.ToDouble(string.IsNullOrEmpty((string)obj) ? 0.0 : obj);
        Console.WriteLine(d.ToString());
    }
