    static void Main(string[] args)
    {
        string file = "D:\\random.txt";
        string find = "random";
        string replace = "Random";
        StringBuilder resultList = new StringBuilder();
        using (var stream = File.OpenText(file))
        {
            while (stream.Peek() >= 0)
            {
                string line = stream.ReadLine();
                if(line == find)
                {
                    line = replace;
                }
                resultList.AppendLine(line);
            }
        }
        string result = resultList.ToString();
        Console.WriteLine(result);
        Console.Read();
    }
