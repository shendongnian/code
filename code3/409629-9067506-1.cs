    public static String[] Split(String input, String delimiter)
        {
            List<String> parts = new List<String>();
            StringBuilder buff = new StringBuilder();
            if (delimiter.Length > 1) //you are splitting on a string not a character
            {
                //perform string searching algorithm here
            }
            else if(delimiter.Length == 0)
            {
                throw new InvalidOperationException("Invalid delimiter.");
            }
            else //you are splitting on a character
            {
                char delimChar = delimiter[0];
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == delimChar)
                    {
                        parts.Add(buff.ToString());
                        buff.Clear();
                    }
                    else
                    {
                        buff.Append(input[i]);
                    }
                }
            }
            return parts.ToArray();
        }
