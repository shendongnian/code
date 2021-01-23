    public class MyModel
    {
       public int SomeProperty { get; set; }
       public int SomeOtherProperty { get; set; } 
        
       public IList<MyDetails> RadioButtonList{ get; set; }
    }
    
    public class MyDetails
    {
       public string Name { get; set; }
       public string Id { get; set; }
    }
