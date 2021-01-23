    public class MyBusinessObject : MyObject<MyBusinessObject>
    { 
     
       public string Name { get; set; } 
     
       public MyBusinessObject()  
       { 
           Name = "Test"; 
           DefineStringIndexer<MyBusinessObject>((item, value) => item.Name == value); 
       } 
     
    } 
