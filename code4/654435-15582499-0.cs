        static void Main(string[] args)
        {
            String testing = "text that i am looking for";
            Console.Write(testing.IndexOf("looking") + Environment.NewLine);
            Console.WriteLine(testing.Substring(testing.IndexOf("looking")));
            Console.ReadKey();
        }
