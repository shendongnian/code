    public abstract class BasePerson
    {
        public string Name{get;set;}
        public string LastName{get;set;}
        public abstract object this[string propertyName]{get;set;}
    }
    
    public abstract class BaseStudent : BasePerson
    {
        public string Test{get;set;}
    }
    
    public class Student : BaseStudent
    {
        //must implement it here since Student isn't abstract!
    }
