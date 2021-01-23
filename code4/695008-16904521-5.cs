    class Program
    {
        static void Main()
        {
            uint u = 1;
            byte b = 2;
            var result1 = new Execute().GetResult(u);
            var result2 = new Execute().GetResult(b);
            sc.WriteLine(result1 + " " + result1.GetType().UnderlyingSystemType);
            sc.WriteLine(result2 + " " + result2.GetType().UnderlyingSystemType);
            sc.Read();
        }
    }
