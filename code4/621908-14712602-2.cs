    public interface IValidatable
    {
       bool IsValid(out outputError);
    }
    
    public class Alias : IValidatable
    {
        public string alias;
        public string aliasSource;
    
        public bool IsValid(out outputError) { ... };
    };
