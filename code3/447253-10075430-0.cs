     private Array SplitSentence(string splitMe)
            {
                if(string.IsNullOrEmpty(splitMe)) return null;
                var splitResult = splitMe.Split(" ".ToArray());
                return splitResult;
            }
