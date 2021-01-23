    ddlLines.DataSource = context.Lines.Where(
      t => !t.ItemLines.Any(x => x.ItemId == ItemId)
    ).Select(
    t => new 
    {
        SomeProperty = t.SomeProperty, 
        SomeOtherProperty = t.SomeOtherProperty }).ToList();
    // Where SomeProperty and SomeOtherProperty are the display/value fields, etc.
