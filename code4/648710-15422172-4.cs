        public static IEnumerable<string> AlternativesOf(string arg)
        {
            //First of all, build up a 2d array of all your options
            var words = arg.Split(' ').Select(w=> w.ToLower()).ToList();
            var options = new List<List<string>>();
            foreach (var word in words)
            {
                if (synonymList.ContainsKey(word))
                {
                    //Add the original word to the list of synonyms
                    options.Add(synonymList[word].Concat(new List<string> { word }).ToList());
                }
                else
                {
                    //Just use the original word only
                    options.Add(new List<string> { word });
                }
            }
            
            //Now return all permutations of the 2d options array
            return AllPermutationsOf("", options, 0);
        }
