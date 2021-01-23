    foreach (var item in doc.Root.Descendants())
    {
        if (item.Name == "orNode" || item.Name == "andNode")
        {
            item.ElementsAfterSelf()
                .ToList()
                .ForEach(x =>
                {
                    x.Remove();
                    item.Add(x);
                });
        }
    }
