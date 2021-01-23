    dynamic bigIntType = new DynamicObjects.LateType("System.Numerics.BigInteger, System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
    
    if (bigIntType.IsAvailable)
    {
    
      var one = bigIntType.@new(1);
      var two = bigIntType.@new(2);
    
      Assert.IsFalse(one.IsEven);
      Assert.AreEqual(true, two.IsEven);
    
      var tParsed = bigIntType.Parse("4");
    
      Assert.AreEqual(true, tParsed.IsEven);
    }
