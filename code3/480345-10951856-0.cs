    private string RegStringZipper(string searchString)
        {
            StringBuilder sb = new StringBuilder();
            char lastChar = new char();
            bool plusFlag = false;
            foreach (char c in searchString)
            {
                if (sb.Length == 0)
                {
                    sb.Append(c);
                    lastChar = c;
                }
                else
                {
                    if (lastChar == c)
                    {//we have a repeating character
                        //Note: Here is also where if you only wanted to filter a specific character, like 0, you would check for it.
                        if (!plusFlag)
                        {//we have not already added the +
                            sb.Append('+');
                            plusFlag = true;
                        }
                        //else do nothing, skip the characer
                    }
                    else
                    {
                        sb.Append(c);
                        plusFlag = false;
                        lastChar = c;
                    }
                }
            }
            return sb.ToString();
        }
