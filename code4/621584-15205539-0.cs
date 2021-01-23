    DelimitedClassBuilder cb = new DelimitedClassBuilder("LineItem");
    // First field
    cb.AddField("Column2", typeof(string));
    // Second field
    cb.AddField("Column1", typeof(string));
    // Third field
    cb.AddField("Column3", typeof(string));
    engine = new FileHelperEngine(cb.CreateRecordClass());
    LineItem[] lineItems = engine.ReadFile("FileIn.txt") as LineItem[];
