    XDocument doc = new XDocument(
        new XDeclaration("1.0", "utf-8", "yes"),
        new XComment("")
    );
    
    XElement snacks = new XElement("Snacks");
    
    foreach (var snack in trashFoods)
    {
        snacks.Add(new XElement("Type", snack.Type));
    
        if(snack.Type == "Doritos")
            snacks.Add(new XElement("GotSauce", snack.Sauce));
    
        snacks.Add(new XElement("Name", snack.Name));
    }
    
    doc.Add(snacks);
