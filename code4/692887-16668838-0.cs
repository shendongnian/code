    public static T GetEnumValueByAttributeString<T>(string code) where T : struct
    {
      if (!typeof(T).IsEnum)
        throw new ArgumentException("T should be an enum");
      var matches = typeof(T).GetFields().Where(f =>
        ((CodeAttribute[])(f.GetCustomAttributes(typeof(CodeAttribute), false))).Any(c => c.Code == code)
        ).ToList();
      if (matches.Count < 1)
        throw new Exception("No match");
      if (matches.Count > 1)
        throw new Exception("More than one match");
      return (T)(matches[0].GetValue(null));
    }
