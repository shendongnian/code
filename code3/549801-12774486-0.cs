    public interface IPerson
    { 
        string Email {get;set;}
        string Name {get;set;}
    }
    
    public class SomeClass
    {
        private IList<T> getEmptyRow<T>() where T : IPerson, new()
        {
            var t = new List<T>();
            t.Add(new T()
            {
                Email = string.Empty,
                Name = string.Empty
            });
    
            return t;
        }
    }
