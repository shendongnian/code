    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string[] words = "Now is the time for all good men to come to the aid of their countrymen".Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length > 0)
            {
                // Generate a list of integers from 0 to words.Length - 1
                List<int> addIndices = Enumerable.Range(0, words.Length).ToList();
                // Shuffle those indices
                Shuffle(addIndices, rand);
                // Pick the number of words that will have dots added
                int addCount = rand.Next(4, Math.Max(4, words.Length));
                // Truncate the array so that it only contains the first addCount items
                addIndices.RemoveRange(addCount, addIndices.Count - addCount);
    
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < words.Length; i++)
                {
                    result.Append(words[i]);
                    if (addIndices.Contains(i)) // If the random indices list contains this index, add dots
                        result.Append('.', rand.Next(1, 7));
                    result.Append(' ');
                }
    
                Console.WriteLine(result.ToString());
            }
        }
    
        private static void Shuffle<T>(IList<T> array, Random rand)
        {
            // Kneuth-shuffle
            for (int i = array.Count - 1; i > 0; i--)
            {
                // Pick random element to swap.
                int j = rand.Next(i + 1); // 0 <= j <= i
                // Swap.
                T tmp = array[j];
                array[j] = array[i];
                array[i] = tmp;
            }
        }
    }
