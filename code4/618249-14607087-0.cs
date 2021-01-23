    void Main()
    {
    	var xml = @"<Bar>
      <Body>
        <Header>
          <A>Value</A>
          <B>true</B>
        </Header> 
        <Data>
          <D>Value</D>
        </Data>
        <Data>
          <D>Value2</D>
        </Data>  
      </Body>
     </Bar>";
    
    	var serializer = new XmlSerializer(typeof(Bar));
    	serializer.Deserialize( new MemoryStream( Encoding.ASCII.GetBytes( xml ) ) ).Dump();
    }
    
    public class Bar
    {
    	public Body Body { get; set; }
    }
    
    public class Body
    {
    	[XmlElement]
    	public Header[] Header { get; set; }
    	
    	[XmlElement]
    	public Data[] Data { get; set; }
    }
    
    public class Header
    {
    	public string A { get; set; }
    	public string B { get; set; }
    }
    
    public class Data
    {
    	public string D { get; set; }
    }
