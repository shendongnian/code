      List<string> listOfWords = new List<string>(words);
                foreach (string i in listOfWords)
                {
                    int c = 0;
                    foreach (string j in words)
                    {
                        if (i.Equals(j))
                            c++;
                    }
                    frequency.Add(c);
                }
