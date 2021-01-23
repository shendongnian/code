    void Main()
    {
    
    var B=new Bar();
    B.Add("aaa","bbb");
    var tFoo=new Foo(){Bar=B};
    DataContractSerializer ser=new DataContractSerializer(typeof(Foo));
    ToXml<Foo>(tFoo).Dump();
    
    }
    
     
    		public static string ToXml<T>(T obj)
    		{
    			DataContractSerializer dataContractSerializer = new DataContractSerializer(obj.GetType());
    			String text;
    			using (MemoryStream memoryStream = new MemoryStream())
    			{
    				dataContractSerializer.WriteObject(memoryStream, obj);
    				byte[] data = new byte[memoryStream.Length];
    				Array.Copy(memoryStream.GetBuffer(), data, data.Length);
    				text = Encoding.UTF8.GetString(data);
    			}
    			return text;
    		}
    	
    	
      
    [System.Runtime.Serialization.DataContract]
    public class Foo
    {
    
      [System.Runtime.Serialization.DataMember]
      public Bar Bar
      { get; set; }
    
      [System.Runtime.Serialization.DataMember]
      public string C { get; set; }
    }
    
    [CollectionDataContract
    	(ItemName="Barentry",
    	KeyName = "A", 
    	ValueName = "B")]
    public class Bar:Dictionary<string,string>{
    }
