    public Dictionary<string, string> GetDelimitedValues(string candidateString,
                                                             char pairDelimeter,
                                                             char valueDelimiter)
        {
          var nameValueStrings = candidateString.Split(new char[] { pairDelimeter },
                                            StringSplitOptions.RemoveEmptyEntries);
          var splitPairs = nameValueStrings.Select(item =>
                                                   item.Split(new char[] { valueDelimiter },
                                                              StringSplitOptions.RemoveEmptyEntries));
    
          var keyValuePairs = splitPairs.Select(x =>
                                                 new KeyValuePair<string, string>(x[0],
                                                  x.Length > 1 ? x[1] : string.Empty));
    
          return keyValuePairs.ToDictionary(x => x.Key, x => x.Value);
        }
