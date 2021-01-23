     using Newtonsoft.Json;
     using System;
     using System.Collections.Generic;
     using System.IO;
     using System.Text;
           public class Program
            {
	         public static void Main()
	         {
    		   //JSON = {"Property1":"as","CollectionProperty":[{"prop1":"1","prop2":"2","prop3":"3"}]}
    		
               //This Top part is just to build a stream 
               //- No need to do this if you are accessing a file 
    		   string JSON = "{\"Property1\":\"SomePropName\",\"CollectionProperty\":"+
               "[{\"prop1\":\"1\",\"prop2\":\"2\",\"prop3\":\"3\"}]}";
    		   byte[] byteArray = Encoding.UTF8.GetBytes(JSON);
    		   //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
    	   	   MemoryStream stream = new MemoryStream(byteArray);
    	       // convert stream to string
    				
    		   var serializer = new JsonSerializer();
    		
    		   StreamReader re = new StreamReader(stream);
    		   JsonTextReader reader = new JsonTextReader(re);
    		   var DeserializedObject = serializer.Deserialize<Collections>(reader);
    		
    		   Console.WriteLine(DeserializeObject.Property1);
    
    		   //"...so I can search data from the file?"
    		   //This is up to you and how you wanna handle it, but you now have JSON
               //Deserialized and stored in memory. 'How to search' depends on objects class
    		   //Also, Original question said he had the JSON. I would recommend using 
               //json2csharp.com/ or jsonutils.com/
    		   //to retrieve the classes in order to Deserialize it to your object. 
    		
               //Note 1: You don't always have to cast it 
               //- I just always try to if and when I can
    		   //Note 2: Because you are using a StreamReader, 
               //this will account for Large JSON Objects 
             }
    	
    	
    	public class Collections
        {
            public List<CollectionProperty> CollectionProperty = new List<CollectionProperty>();
            public string Property1;
        }
    
        public class CollectionProperty
        {
            public string prop1 { get; set; }
            public string prop2 { get; set; }
            public string prop3 { get; set; }
        }
}
