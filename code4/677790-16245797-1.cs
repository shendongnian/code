            foreach (var tag in pattern.Split(','))
            {
                string tg = tag;
                while (tg.StartsWith(" ")) tg = tg.Remove(0,1);
                innerList = new List<List<string>>();
                foreach (var varyword in tg.Split(' '))
                {
                    innerList.Add(varyword.Split('|').ToList<string>());
                }
                //Adam's code
                List<String> combinations = new List<String>();
                int n = innerList.Count;
                int[] counter = new int[n];
                int[] max = new int[n];
                int combinationsCount = 1;
                for (int i = 0; i < n; i++)
                {
                    max[i] = innerList[i].Count;
                    combinationsCount *= max[i];
                }
                int nMinus1 = n - 1;
                for (int j = combinationsCount; j > 0; j--)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < n; i++)
                    {
                        builder.Append(innerList[i][counter[i]]);
                        if (i < n - 1) builder.Append(" "); //my addition to insert whitespace between words
                    }
                    combinations.Add(builder.ToString());
                    counter[nMinus1]++;
                    for (int i = nMinus1; i >= 0; i--)
                    {
                        // overflow check
                        if (counter[i] == max[i])
                        {
                            if (i > 0)
                            {
                                // carry to the left
                                counter[i] = 0;
                                counter[i - 1]++;
                            }
                        }
                    }
                }
                //end
                if(combinations.Count > 0)
                    combinationsList.Add(combinations);
            }
        }
        public bool IsMatch(string textToCheck)
        {
            if (combinationsList.Count == 0) return true;
            string t = _caseSensitive ? textToCheck : textToCheck.ToLower();
            return combinationsList.All(tg => tg.Any(c => t.Contains(c)));
        }
