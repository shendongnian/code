    var agg = root.XPath("//TaggedValue[@tag='ea_type' and @value={0}]", "Aggregation");
    List<Dictionary<string,string>> list = agg.Select(a => a.Parent.Elements()
            .ToDictionary(b => b.Attribute("tag").Value, 
                          b => b.Attribute("value").Value))
            .ToList();
