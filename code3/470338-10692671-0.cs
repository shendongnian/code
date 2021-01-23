    public void TestIt()
    {
        PlanItem item = new PlanItem();
        item.Rules.Add( (item) => {  !string.IsNullOrEmpty(item.Name); });
        item.Rules.ForEach( (rule) => { if(!rule(item) uhOh(item, outputStream);} );
    }
