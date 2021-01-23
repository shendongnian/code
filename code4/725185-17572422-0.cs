    public static string GetBoolString(IEnumerable<bool> bools) 
    {
      var boolArray = bools.ToArray();
      char[] data = new char[boolArray.Length];
      for (int i = 0; i < boolArray.Length; i++)
      {
        data[i] = boolArray[i] ? '1' : '0';
      }
      return new string(data);
    }
