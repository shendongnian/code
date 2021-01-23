    public Array Convert(Array a) {
      var type = a.GetValue(0).GetType();
      var result = Array.CreateInstance(type, a.Length);
      for (int i = a.GetLowerBound(0); i <= a.GetUpperBound(0); i++) {
        result.SetValue(a.GetValue(i), i - a.GetLowerBound(0));
      }
      return result;
    }
