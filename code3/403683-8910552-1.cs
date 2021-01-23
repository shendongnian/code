    public override void MyMethod(string s = "bbb")
    {
      Console.Write("derived: ");
      base.MyMethod(s);
    }
