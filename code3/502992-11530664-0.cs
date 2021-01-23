    object obj = this; //your object containing methods
    XDocument xDoc = XDocument.Parse(xml);
    Type type = obj.GetType(); 
    foreach (var action in xDoc.Descendants("Action"))
    {
        MethodInfo mi = type.GetMethod(action.Attribute("Word").Value);
        var dict =  action.Descendants().ToDictionary(
                                             d=>d.Attribute("Name").Value,
                                             d=>d.Attribute("Value").Value);
        object[] parameters = mi.GetParameters()
            .Select(p => Convert.ChangeType(dict[p.Name],p.ParameterType))
            .ToArray();
        var expectedResult = mi.Invoke(obj, parameters);
        Debug.Assert(expectedResult.Equals(dict["expectedResult"]));
    }
