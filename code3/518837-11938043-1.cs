    using System;
    using System.Text;
    
    public class Program
    {
        public static void Main()
        {
            DateTime start, end;
            int numberOfIterations = 100000000;
            start = DateTime.UtcNow;
            for (int i = 0; i < numberOfIterations; ++i)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hello" + "How" + "are" + "you");
            }
            end = DateTime.UtcNow;
            DisplayResult("sb.Append(\"Hello\" + \"How\" + \"are\" + \"you\")", start, end);
    
            start = DateTime.UtcNow;
            for (int i = 0; i < numberOfIterations; ++i)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hello").Append("How").Append("are").Append("you");
            }
            end = DateTime.UtcNow;
            DisplayResult("sb.Append(\"Hello\").Append(\"How\").Append(\"are\").Append(\"you\")", start, end);
    
            string a = "Hello";
            string b = "How";
            string c = "are";
            string d = "you";
    
            start = DateTime.UtcNow;
            for (int i = 0; i < numberOfIterations; ++i)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(a + b + c + d);
            }
            end = DateTime.UtcNow;
            DisplayResult("sb.Append(a + b + c + d)", start, end);
    
            start = DateTime.UtcNow;
            for (int i = 0; i < numberOfIterations; ++i)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(a).Append(b).Append(c).Append(d);
            }
            end = DateTime.UtcNow;
            DisplayResult("sb.Append(a).Append(b).Append(c).Append(d)", start, end);
    
            Console.ReadLine();
        }
    
        private static void DisplayResult(string name, DateTime start, DateTime end)
        {
            Console.WriteLine("{0,-60}: {1,6:0.000}s", name, (end - start).TotalSeconds);
        }
    }
