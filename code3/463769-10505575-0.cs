    public enum Test
    {
      [Description("1,2,3")]
      a = 123,
      [Description("3,4,5")]
      b = 345,
      [Description("6,7,8")]
      c = 678
    }
    //Get attributes from the enum
        var items = 
           typeof(Test).GetEnumNames()
            .Select (x => typeof(Test).GetMember(x)[0].GetCustomAttributes(
               typeof(DescriptionAttribute), false))
            .SelectMany(x => 
               x.Select (y => new ListItem(((DescriptionAttribute)y).Description)))
        
    //Add items to ddl
        foreach(var item in items)
           ddl.Items.Add(item);
