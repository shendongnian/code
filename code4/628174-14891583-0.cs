    List<Decimal> consArray = new List<decimal>();
    Decimal d = Decimal.MinValue;
    // You don't need to try-catch a Decimal.TryParse
    // Decimal.TryParse(item.Value, out d));
    
    try
    {
        d = Decimal.Parse(item.Value)
    }
    catch
    {
        // Handle exception
    }
    Assert.AreEqual(0.123, d);
    
    // Does the list add anything at all? In this sample it seems a bit redundant
    consArray.Add(d);
