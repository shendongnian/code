    List<string> properties = new List<string>() { {"ResultPrefix"}, {"ProfileResult"}};
    
    foreach (dynamic d in ListProperties(properties, cellValues))
    {
         Console.WriteLine(d.ResultPrefix);
    }
    public static List<dynamic> ListProperties(List<string> properties, List<ChemistryResult> chemistryResults)
    {
        List<dynamic> output = new List<dynamic>();
    
        foreach (ChemistryResult chemistryResult in chemistryResults)
        {
            IDictionary<string, Object> result = new ExpandoObject();
    
            foreach (string property in properties)
            {
                PropertyInfo propertyInfo = typeof(ChemistryResult).GetProperty(property);
    
                result[property] = propertyInfo.GetValue(chemistryResult);
            }
    
            output.Add(result);
        }
    
        return output;
    }
