    public class Parent 
    {
     public string name{get;set;} 
    }
    
    public class child : Parent{}
    
    var myClass = new Child()
    Parent foo  = myClass as Parent
    if ( foo == null ) Debug.WriteLine("foo is NOT of type Parent");
