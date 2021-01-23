            private static void CharProducer(ConcurrentBag<string> words, BlockingCollection<char> output)
            {
                while(!words.IsEmpty)
                {
                    string word;
                    if(words.TryTake(out word))
                    {
                        foreach (var c in GetCharacters(word))
                        {
                            output.Add(c);
                        }
                    }
                }
            }
