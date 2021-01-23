     internal static Dictionary<string, Dictionary<string, object>> OperationDic(Dictionary<string, Dictionary<string, object>> a, Dictionary<string, Dictionary<string, object>> b, string operation)
        {
            var result = new Dictionary<string, Dictionary<string, object>>(a);
            switch (operation)
            {
                case "+":                  
                // now check to see if we can add stuff from b
                foreach (var entryOuter in b)
                {
                  Dictionary<string, object> existingValue;
                  if (result.TryGetValue(entryOuter.Key, out existingValue))
                  {
                      Dictionary<string, object> Value = entryOuter.Value;
                      result[entryOuter.Key] = existingValue.Concat(Value).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
                  }
                  else
                  {
                    // new entry
                    result.Add(entryOuter.Key, entryOuter.Value);
                  }
                }
                return result;
                default:                    
                    throw new Exception("FAIL ...");
            }
        }
