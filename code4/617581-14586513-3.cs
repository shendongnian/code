    void Main()
    {
          var specialType = new SpecialType()
                    {
                        Id = 1,
                        Name = "test"
                    };
    
                var serializer = new XmlSerializer(typeof (SpecialType));
               
    			XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
    			XmlAttributes attrs = new XmlAttributes();
    		
    			// Create an XmlRootAttribute to override.
    			XmlRootAttribute attr = new XmlRootAttribute();
    			attr.ElementName = "special";
    			
    			// Add the XmlRootAttribute to the collection of objects.
    			attrs.XmlRoot=attr;	
    			attrOverrides.Add(typeof(BaseType),  attrs);
          		var des = new XmlSerializer(typeof (BaseType), attrOverrides);
    					
                using (var memeStream= new MemoryStream())
                {
                    serializer.Serialize(memeStream, specialType);
                    memeStream.Flush();
    
                    memeStream.Seek(0, SeekOrigin.Begin);
                    var instance = des.Deserialize(memeStream); 
                }
            
    }
    
    [XmlInclude(typeof(SpecialType))]
    [XmlType("baseType")]
    public class BaseType
    {
          public long Id { get; set; }
    }
    
    [XmlRoot("special")]
    public class SpecialType : BaseType
    {
            public string Name { get; set; }
    }
