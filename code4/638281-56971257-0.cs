    public int FindClosingBracketIndex(string text, char openedBracket = '{', char closedBracket = '}')
    {
                int index = text.IndexOf(openedBracket);
                int bracketCount = 1;
                var textArray = text.ToCharArray();
    
                for (int i = index + 1; i < textArray.Length; i++)
                {
                    if (textArray[i] == openedBracket)
                    {
                        bracketCount++;
                    }
                    else if (textArray[i] == closedBracket)
                    {
                        bracketCount--;
                    }
    
                    if (bracketCount == 0)
                    {
                        index = i;
                        break;
                    }
                }
    
                return index;
    }
