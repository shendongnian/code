     public int RepeatedLetters(string word)
            {
                var count = 0;
                for (var i = 0; i < word.Count()-1; i++)
                {
                    if (word[i] == word[i+1])
                    {
                        count++;
                    }
                }
                return count;
            }
