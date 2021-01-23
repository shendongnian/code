        static void Main(string[] args)
        {
            var z = GetPermutations("ABCDEFGH", '-', 16);
            foreach (string s in z)
                Console.WriteLine(s);
            Console.ReadKey();
        }
        private static List<string> GetPermutations(string originalString, char padChar, int length)
        {
            if (length <= originalString.Length)
                return null;
            var list = new List<string>();
            int originalLength = originalString.Length;
            int ndx = 0;
            string beginString = originalString.PadLeft(length, padChar);
            string endString = originalString.PadRight(length, padChar);
            int lenDifference = endString.Length - originalString.Length;
            
            list.Add(beginString);
            while (lenDifference > 0)
            {
                while (ndx < originalLength)
                {
                    beginString = SwapCharacters(beginString, lenDifference + ndx - 1, lenDifference + ndx);
                    list.Add(beginString);
                    ndx++;
                }
                ndx = 0;
                lenDifference--;
            }
            return list;
        }
        private static string SwapCharacters(string value, int position1, int position2)
        {
            char[] array = value.ToCharArray();
            char temp = array[position1]; 
            array[position1] = array[position2];
            array[position2] = temp; 
            return new string(array);
        }
