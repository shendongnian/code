    public static List<float> GetListFloatKey(string keys)
    {
      List<float> result = new List<float>();
      string s = GetKey(keys);
      string[] items = s.Split(new char[] { ',' });
      float f;
      foreach (string item in items)
      {
        if (float.TryParse(item, out f))
          result.Add(f);
      }
      return result;
    }
