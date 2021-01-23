    string data = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <Root>
      <a1>val1</a1>
      <a2>val2</a2>
      <Parameter>
        <ParameterName>param1</ParameterName>
        <ParameterValue>paramval1</ParameterValue>
      </Parameter>
      <Parameter>
        <ParameterName>param2</ParameterName>
        <ParameterValue>paramval2</ParameterValue>
      </Parameter>
    </Root>";
    
    var elements = XDocument.Parse( data )
                            .Element("Root")
                            .Descendants();
    
    var asTupleChildren =  elements.Where (e => e.HasElements)
                                   .Select (e => new Tuple<string,string>(e.Element("ParameterName").Value, e.Element("ParameterValue").Value ));
    
    var asTupleElements =  elements.Where (e => e.HasElements == false)
                                   .Where (e => e.Name != "ParameterName" && e.Name != "ParameterValue" )
                                   .Select (e => new Tuple<string,string>(e.Name.ToString(), e.Value ));
    
    
    var asDictionary =  asTupleElements.Concat(asTupleChildren)
                                       .ToDictionary (te => te.Item1, te => te.Item2);
    
    
    /* asDictionary is a Dictionary<String,String> (4 items)
    
    a1 val1
    a2 val2
    param1 paramval1
    param2 paramval2
    
    */
