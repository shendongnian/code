            List<Vals> ListWords = new List<Vals>();
            foreach (string str in s.Split(' '))
            {
                if (str.Contains("ENDIF"))
                    ListWords.Add(Vals.ENDIF);
                else if (str.Contains("ELSE"))
                    ListWords.Add(Vals.ELSE);
                else if (str.Contains("THEN"))
                    ListWords.Add(Vals.THEN);
                else if (str.Contains("IF"))
                    ListWords.Add(Vals.IF);
            }
