    public interface IDatabase
    {
        object SomeMethod(object data);
        
        SomeObject SomeOtherMethod(SomeObject data1, SomeObject data2);
    }
        
    public class SpecificDatabase : IDatabase
    {
        public object SomeMethod(object data)
        {
            return data;
        }
        
        public SomeObject SomeOtherMethod(SomeObject data1, SomeObject data2)
        {
            return data2;
        }
    }
        
    public class SomeObject { }
