    public interface IPersonProperties
    {
       string PersonName { get; set; }
       int Age { get; set; }
       // if you want a function that is common between them too
       bool SomeCommonFunction(string whateverParms);
       etc...
    }
    
    public class Man : IPersonProperties
    {
       // these required as to support the IPersonProperties
       public string PersonName { get; set; }
       public int Age { get; set; }
       public bool SomeCommonFunction(string whateverParms)
       {  doSomething;
          return true;
       }
    
       // you can still have other stuff specific to man class definition
       public string OtherManBasedProperty { get; set;}
       public void SomeManFunction()
       {  // do something specific for man here }
    }
    
    public class Woman : IPersonProperties
    {
       // these required as to support the IPersonProperties
       public string PersonName { get; set; }
       public int Age { get; set; }
    
       public bool SomeCommonFunction(string whateverParms)
       {  doSomething;
          return false;
       }
       // you can still have other stuff specific to WOMAN class definition
       public string OtherWOMANBasedProperty { get; set;}
       public void SomeWomanFunction()
       {  // do something specific for man here }
    }
