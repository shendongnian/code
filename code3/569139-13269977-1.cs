    public Array Convert(Array a) {
      if (a.GetLength(0) == 0){
        return new int[0];
      }
      var type = a.GetValue(0).GetType();
      var result = Array.CreateInstance(type, a.Length);
      for (int i = 0; i < a.GetLength(0); i++) {
        result.SetValue(a.GetValue(i), i);
      }
      return result;
    }
