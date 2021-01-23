    enum MyEnum
    { 
      Option,
      Option1 = 1, 
      Option2 = 2
    }
    string stringValue = "0";
    if((MyEnum)Enum.Parse(typeof(MyEnum), stringValue) == MyEnum.Option)
    {
       //Do what you need
    }
