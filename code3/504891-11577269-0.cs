    public static void MyMethod(object obj)
    {
      var iDict = obj as IDictionary;
      if (iDict != null)
      {
        var dictStrStr = iDict.Cast<DictionaryEntry>()
          .ToDictionary(de => de.Key.ToString(), de => de.Value.ToString());
        // use your dictStrStr        
      }
      else
      {
        // My object is not an IDictionary
      }
    }
