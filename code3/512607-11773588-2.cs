        private static void Main(string[] args)
        {
            var result = InsertHere("Lorem ipsum dolor sit amet,", 10, 3);
            Console.Write("\"");
            Console.Write(result);
            Console.WriteLine("\""); //quotes to show we dealt with edge cases correctly
            Console.ReadLine();
        }
