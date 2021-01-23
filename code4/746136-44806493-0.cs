    public class XMLExport
    {
       [YAXElementFor("")]
       [YAXSerializeAs("1")]
       public string 1 { get; set; }
    
       [YAXElementFor("1")]
       [YAXSerializeAs("1a")]
       public string 1a { get; set; }
    
       [YAXElementFor("1")]
       [YAXSerializeAs("1b")]
       public string 1b { get; set; }
    
       [YAXElementFor("1/1a/1b")]
       [YAXSerializeAs("1c")]
       public string 1c { get; set; }
    }
