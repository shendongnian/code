    return Regex.Replace(input,
                         @"\S+",
                         (match) =>
                         {
                                 var word = match.Value;
    
                                 var formatException = yourListOfTitleCaseExceptions.FirstOrDefault(e => e.Trim().Equals(word, StringComparison.InvariantCultureIgnoreCase));
    
                                        if (formatException == null)
                                        {
                                            Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(word.ToLower())
                                        }
    
                                        return formatException.Trim();
    
                                    });
