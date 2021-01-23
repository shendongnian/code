    DelimitedClassBuilder cb = new DelimitedClassBuilder("Order");
    // First field
    cb.AddField("OrderID", typeof(int));
    // Second field
    cb.AddField("CustomerID", 8, typeof(string));
    // Third field
    cb.AddField("OrderDate", typeof(DateTime));
    cb.LastField.Converter.Kind = ConverterKind.Date; 
    cb.LastField.Converter.Arg1 = "ddMMyyyy";
    engine = new FileHelperEngine(cb.CreateRecordClass());
    Order[] orders = engine.ReadFile("FileIn.txt") as Order[]; 
