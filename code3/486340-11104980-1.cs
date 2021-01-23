        // (to be clear) This is Elias' (original) code modified.
        static void Main(string[] args)
        {
            string input = "As he DIDN'T ACHIEVE Success, he was fired";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("didn't achieve success", "failed miserably");
            string temp = input;
            foreach (var entry in map)
            {
                string key = entry.Key;
                string value = entry.Value;
                temp = Regex.Replace(temp, key, match =>
                {
                    string[] matchSplit = match.Value.Split(' ');
                    string[] valueSplit = value.Split(' ');
                    // Set the number of words to the lower one.
                    // If they're the same, it doesn't matter.
                    int numWords = (matchSplit.Length <= valueSplit.Length) 
                        ? matchSplit.Length
                        : valueSplit.Length;
                    // only first letter of first word capitalized
                    // only first letter of every word capitalized
                    // all letters capitalized
                    char[] result = value.ToCharArray(); ;
                    for (int i = 0; i < numWords; i++)
                    {
                        if (char.IsUpper(matchSplit[i][0]))
                        {
                            bool allIsUpper = true;
                            int c = 1;
                            while (allIsUpper && c < matchSplit[i].Length)
                            {
                                if (!char.IsUpper(matchSplit[i][c]) && char.IsLetter(matchSplit[i][c]))
                                {
                                    allIsUpper = false;
                                }
                                c++;
                            }
                            // if all the letters of the current word are true, allIsUpper will be true.
                            int arrayPosition = ArrayPosition(i, valueSplit);
                            Console.WriteLine(arrayPosition);
                            if (allIsUpper)
                            {
                                for (int j = 0; j < valueSplit[i].Length; j++)
                                {
                                    result[j + arrayPosition] = char.ToUpper(result[j + arrayPosition]);
                                }
                            }
                            else
                            {
                                // The first letter.
                                result[arrayPosition] = char.ToUpper(result[arrayPosition]);
                            }
                        }
                    }
                    
                    return new string(result);
                }, RegexOptions.IgnoreCase);
            }
            Console.WriteLine(temp); 
        }
        public static int ArrayPosition(int i, string[] valueSplit)
        {
            if (i > 0)
            {
                return valueSplit[i-1].Length + 1 + ArrayPosition(i - 1, valueSplit);
            }
            else
            {
                return 0;
            }
            return 0;
        }
