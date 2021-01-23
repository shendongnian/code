                var tokenCmd = cmd.Split(' ');
                string currentKey = "";
                foreach (var token in tokenCmd)
                {
                    if ((char.IsLetterOrDigit(token[0])) &&
                        (!keys.ContainsKey(currentKey)) ||
                        (keys[currentKey].Any()))
                    {
                        currentKey = token;
                        keys.Add(currentKey,
                                 new Dictionary<string, string>());
                    }
                    else
                    {
                        var splitToken = new[] { token, "" };
                        if (token.Contains(':'))
                        {
                            splitToken = token
                                .Replace("/", "")
                                .Split(':');
                        }
                        keys[currentKey].Add(splitToken[0],
                                             splitToken[1]);
                    }
                }
