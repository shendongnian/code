            Dictionary<string, List<string[]>> allPairs = new Dictionary<string, List<string[]>>();
            foreach (string currentLine in allLines)
            {
                string[] lineContent = currentLine.Split(" "); //or something like it. Maybe it should be a TAB
                string[] newPair = new string[2];
                newPair[0] = lineContent[1];
                newPair[1] = lineContent[2];
                if (allPairs[lineContent[0]] == null)
                {
                    allPairs[lineContent[0]] = new List<string[]>();
                }
                allPairs[lineContent[0]].Add(newPair);
            }
