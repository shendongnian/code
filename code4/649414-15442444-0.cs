        static void Main(string[] args)
        {
            string[] StringValues = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10","Not Number" };
            List<int> ConvertedStrings = new List<int>();
            foreach (string S in StringValues)
            {
                ConvertedStrings = ParseStringToInt(S, ConvertedStrings);
            }
            Console.WriteLine();
            Console.WriteLine("Max Value: " + ConvertedStrings.Max().ToString());
            Console.WriteLine("Min Value: " + ConvertedStrings.Min().ToString());
            Console.ReadLine();
        }
        static private List<int> ParseStringToInt(string Input, List<int> ConvertedStrings)
        {
            int ConvertedValue = 0;
            if (int.TryParse(Input, out ConvertedValue))
            {
                Console.WriteLine(Input + " sucessfully parsed and added...");
                ConvertedStrings.Add(ConvertedValue);
                return ConvertedStrings;
            }
            else
            {
            Console.WriteLine(Input + " failed to parse...");
            }
            return ConvertedStrings;
        }
