    public class Utility : IUtility
    {
        public T CreateAndRegister<T>(string id) where T : IIdentifiable, new()
        {
            T result = new T();
            result.Id = id;
            
            // do your registration 
            return result;
        }
        public T CreateAndRegister<T>(ComplexInitInfo somethingElse) where T : ISomethingElseable, new()
        {
            T result = new T();
            result.Id = somethingElse.SomeId;
            result.SomethingElse = somethingElse.SomethingElse;
            // do your registration 
            return result;
        }
    }
