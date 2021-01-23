    static void Main(string[] args)
    {
        string myVar = "abcdef";
        Stopwatch stopwatch = Stopwatch.StartNew();
    
        for (int j = 0; j < 10000; j++)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                //UNCOMMENT ONE OF THESE TESTS
                //Test1
                sb.Append("my string " + myVar + " my string");
    
                //Test2
                //sb.AppendFormat("my string {0} my string", myVar);
    
                //Test3
                //sb.Append("my string ");
                //sb.Append(myVar);
                //sb.Append(" my string");
            }
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");
    }
