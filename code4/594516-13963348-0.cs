    Dictionary<String, Double> numericValues = valuesDictionary
          .Where(
                pair => 
                    { 
                        double doubleValue; 
                        return double.TryParse(subs.Value, out doubleValue);                
                    })
          .ToDictionary(pair => pair.Key, pair => double.Parse(pair.Value);
