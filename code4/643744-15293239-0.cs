                string newSearchPhrase      = string.Empty;
                var BannedWords             = _IGBW.BannedWords().ToList();
                foreach (string searchWord in TextClean.Split(' '))
                    {
                    if (!BannedWords.Select(word=>word.ToLower()).Contains(searchWord.ToLower()))
                        { 
                            newSearchPhrase += searchWord +" ";
                        }
                    }
                string bannedWordsRemoved = newSearchPhrase;
