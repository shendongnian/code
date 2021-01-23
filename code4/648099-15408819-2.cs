        static void Main(string[] args)
        {
            var listOfCharacters = "abcdefghijklmnopqrstuvwxyz".ToList();
            var occurences = new Dictionary<char, int>();
            foreach (var character in listOfCharacters)
            {
                occurences.Add(character, 0);
            }
            var provider = new RNGCryptoServiceProvider();
            var bytes = new byte[4];
            for (int i = 0; i < 1000000; i++)
            {
                provider.GetBytes(bytes);
                var number = BitConverter.ToInt32(bytes, 0);
                var index = Math.Abs(number % listOfCharacters.Count);
                occurences[listOfCharacters[index]]++;
            }
            var orderedOccurences = occurences.OrderBy(kvp => kvp.Value);
            var minKvp = orderedOccurences.First();
            var maxKvp = orderedOccurences.Last();
            Console.WriteLine("Min occurence: " + minKvp.Key + " Times: " + minKvp.Value);
            Console.WriteLine("Max occurence: " + maxKvp.Key + " Times: " + maxKvp.Value);
            Console.WriteLine("Difference: " + (maxKvp.Value - minKvp.Value));
            Console.ReadKey();
        }
