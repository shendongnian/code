    try
    {
        //Logic to load your file
        var xelmOriginal = new XElement("Root");
        for (int i = 0; i < 500000; i++)
        {
            var item = new XElement("Item");
            item.SetAttributeValue("id", i);
            xelmOriginal.Add(item);
        }
        // Logic to transform each element
         
        var xelmRootTransformed = new XElement("Root");
        foreach (var element in xelmOriginal.Elements())
        {
            var transformedItem =
                new XElement("Transformed",
                                element.
                                    Attributes()
                                    .Single(x => x.Name.LocalName.Equals("id")));
            xelmRootTransformed.Add(transformedItem);
        }
        //Logic to save your transformed file
    }catch(Exception e)
    {
        Console.WriteLine("Failed");
        return;
    }
    Console.WriteLine("Success");
