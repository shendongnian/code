    public interface IValidatable
    {
       bool IsValid(...);
    }
    
    public struct Alias
    {
        public string alias;
        public string aliasSource;
    
        public bool IsValid(...) { ... };
    };
