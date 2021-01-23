        public static IEnumerable<string> AllPermutationsOf(string sentence, List<List<string>> options, int count)
        {
            if (count == options.Count)
            {
                yield return sentence;
            }
            else
            {
                foreach (string option in options[count])
                {
                    foreach (var childOption in AllPermutationsOf(sentence + " " + option, options, count + 1))
                    {
                        yield return childOption;
                    }
                }
            }
        }
