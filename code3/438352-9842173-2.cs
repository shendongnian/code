    public class SomeClass<T> where T: new() 
    {
        public static T CreateNewT()
        {
             // you can only write "new T()" when you also have "where T: new()"
             return new T();
        }
    }
