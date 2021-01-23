    public static string[] SplitProxy(string text)
            {
                var list = new List<string>();
                var tokens = text.Split(new char[] { ' ' });
                var currentToken = new StringBuilder();
    
                foreach (var token in tokens)
                {
                    if (token.ToLower().Substring(0, 4) == "smtp")
                    {
                        if (currentToken.Length > 0)
                        {
                            list.Add(currentToken.ToString());
                            currentToken.Clear();
                        }
    
                        list.Add(token);
                    }
                    else
                    {
                        currentToken.Append(token);
                    }
                }
    
                if (currentToken.Length > 0)
                            list.Add(currentToken.ToString());
    
                return list.ToArray();
            }
