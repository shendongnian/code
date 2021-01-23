    public static int GetPrivateField(this MyObject obj)
    {
      PrivateObject po = new PrivateObject(obj);
      return (int)po.GetField("_privateIntField");
    }
