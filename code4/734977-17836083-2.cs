    public override void CallMethod(ref object obj)
    {
      Type type = obj.GetType(obj);
      PropertyInfo property = type.GetProperty("Result");
      property.SetValue(obj, "somevalue");
    }
