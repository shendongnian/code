        // first copy everything from a
        var result = new Dictionary<string, Dictionary<string, object>>(a);
        
        // now check to see if we can add stuff from b
        foreach (var entryOuter in b)
        {
          Dictionary<string, object> existingValue;
          if (result.TryGetValue(entryOuter.Key, out existingValue))
          {
            // there's already an entry, see if we can add to it
            foreach (var entryInner in entryOuter.Value)
            {
              if (existingValue.ContainsKey(entryInner.Key))
                throw new Exception("How can I merge two objects? Giving up.");
              existingValue.Add(entryInner.Key, entryInner.Value);
            }
          }
          else
          {
            // new entry
            result.Add(entryOuter.Key, entryOuter.Value);
          }
        }
        return result;
