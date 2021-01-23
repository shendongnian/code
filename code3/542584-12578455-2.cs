     Dictionary<string, List<SomeType>> GetKeyPairValues()
     {
          return dic.Values.SelectMany(d => d)
                           .GroupBy(p => p.Key)
                           .ToDictionary(g => g.Key, 
                                         g => g.SelectMany(gg => gg.Value).ToList());
     }
