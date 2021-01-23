    void Main()
    {
        var dto = new MyDto();
        dto.Tada = new Type[] { this.GetType() };
        DataContractSerializer ser =
            new DataContractSerializer(typeof(MyDto));
    
        var ms = new MemoryStream();
        ser.WriteObject(ms, dto);
    	
        ms.Dump();
        dto.Dump();
    }
    
    public class MyDto
    {
       public Type[]  Tada { get; set; }
    }
