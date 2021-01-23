    struct MyStruct
    {
      public string name;
      public double amount;
    }
    
    var a = Products.AsEnumerable()
        .Select(p => new MyStruct
        {
            name = p.Name,
            amount = p.Amount
        };
