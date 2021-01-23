    private int NoOfWhiteSpaces(string s)
            {
                char[] sArray = s.ToArray<char>();
                int count = 0;
                for (int i = 0; i < (sArray.Length - 1); i++)
                {
                    if (sArray[i] == ' ') count++;
                }
                return count;
            }
            private string Reverse(string s)
            {
                char[] sArray = s.ToArray<char>();
                int startIndex = 0, lastIndex = 0;
                string[] stringArray = new string[NoOfWhiteSpaces(s) + 1];
                int stringIndex = 0, whiteSpaceCount = 0;
                    
                for (int x = 0; x < sArray.Length; x++)
                {
                    if (sArray[x] == ' ' || whiteSpaceCount == NoOfWhiteSpaces(s))
                    {
                        if (whiteSpaceCount == NoOfWhiteSpaces(s))
                        {
                            lastIndex = sArray.Length ;
                        }
                        else
                        {
                            lastIndex = x + 1;
                        }
                        whiteSpaceCount++;
                        
                        char[] sWordArray = new char[lastIndex - startIndex];
                        int j = 0;
                        for (int i = startIndex; i < lastIndex; i++)
                        {
                            sWordArray[j] = sArray[i];
                            j++;
                        }
                        
                        stringArray[stringIndex] = new string(sWordArray);
                        stringIndex++;
                        startIndex = x+1;
                    }
    
                }
                string result = "";
                for (int y = stringArray.Length - 1; y > -1; y--)
                
                    {
                        if (result == "")
                        {
    
                            result = stringArray[y];
                        }
                        else
                        {
                            result = result + ' ' + stringArray[y];
                        }
                }
                return result;
            }
