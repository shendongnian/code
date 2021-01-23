    var doubleAR = new List<List<Double>>()
    {
       new List<double>(){ 12.5, 12.6, 12.7 },
       new List<double>(){ .06 },
       new List<double>(){ 1.0, 2.0 }
    };
    
       var asXml = new XElement("Data",
                                doubleAR.Select(sList => new XElement("Doubles", sList.Select (sl => new XElement("Double", sl) )))
                               );
    
    	Console.WriteLine ( asXml );
    /* Output
    <Data>
      <Doubles>
        <Double>12.5</Double>
        <Double>12.6</Double>
        <Double>12.7</Double>
      </Doubles>
      <Doubles>
        <Double>0.06</Double>
      </Doubles>
      <Doubles>
        <Double>1</Double>
        <Double>2</Double>
      </Doubles>
    </Data> */
    
    // Then back
       List<List<Double>> asDoubleArray =
             XDocument.Parse( asXml.ToString() )
                      .Descendants("Doubles")
                      .Select (eDL => eDL.Descendants("Double")
                                         .Select (dl => (double) dl))
                                          .ToList())
                      .ToList();
