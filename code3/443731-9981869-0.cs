    private static Dictionary<string,int> CountNodesByName( TextReader reader , string xpathExpression )
    {
      XmlDocument xml = new XmlDocument() ;
      xml.Load( reader );
      
      Dictionary<string,int> instance = xml.DocumentElement
                                        .SelectNodes( xpathExpression )
                                        .Cast<XmlNode>()
                                        .GroupBy(
                                          x            => x.Name ,
                                          (name,nodes) => Tuple.Create( name , nodes.Count() )
                                          )
                                        .ToDictionary( x => x.Item1 , x => x.Item2 )
                                        ;
      
      return instance ;
    }
