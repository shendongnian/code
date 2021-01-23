                            /*DataRow dr = dt.NewRow();
                            string SearchTerm = Word;
                            var MatchQuery = from word in Words
                                             where word == SearchTerm
                                             select word;
                            int WordCount = MatchQuery.Count();
                            
                            Length = SearchTerm.Length;*/
                            if (Word.Length > 1)
                            {
                                if (!CheckedWords.ContainsKey(Word))
                                    CheckedWords.Add(Word,1);
                                else
                                    CheckedWords[Word]++;
                            }
