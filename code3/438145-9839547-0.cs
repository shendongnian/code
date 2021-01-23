    enum1pos = -1;
    enum2pos = 0;
      Value2 = enum2.Next()
      enum2pos++;
    List<int> SkipList = new SkipList();
    while(enum1 has values left)
    {
      Value1 = enum1.Next()
      enum1pos++;
      //Skip over moved items.
      while (SkipList.Count > 0 && SkipList[0] == enum2.Position)
      {
        Value2 = enum2.Next()
        enum2pos++;
      }
      if (Value1 == Value2)
        Value2 = enum2.Next()
        enum2pos++;
        continue;
      int temp = enum2pos;
      while(Value1 !=Value and enum2 has more values)
      {
        Value2 = enum2.Next();
        enum2pos++;
      }
      if(Value1 != Value2)
        ItemDeleted(Value1);
      else
      {
        ItemMoved(Value1, enum2pos);
        SkipList.Add(enum2pos);
      }
      //This is expensive for IEnumerable!
      enum2.First();
      loop temp times
        enum2.Next();
      //if 
    }
    while (enum2 has values left)
    {
      while (SkipList.Count > 0 && SkipList[0] == enum2.Position)
      {
        Value2 = enum2.Next()
        enum2pos++;
      }
      if (enum2 has values left)
      Added(Value2, enum2pos)
    }
