    // allTypesWithReqdAttributes should contain list of types with JIMSExportAttribute
    IEnumerable<object> attributeList = allTypesWithReqdAttribute.SelectMany(x => x.GetCustomAttributes(true));
    var myAttributeList = attributeList.OfType<JIMSExportAttribute>();
    // assumes JIMSExportAttribute has ModuleName and ContractName properties
    var groups = myAttributeList.GroupBy(x => x.ModuleName, x => x.ContractName);
    var result = groups.ToDictionary(x => x.Key, x => new List<string>(x));
    foreach (var group in groups)
    {
        Console.WriteLine("module name: " + group.Key);
        foreach (var item in group)
        {
            Console.WriteLine("contract name: " + item);
        }
    }
