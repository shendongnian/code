    public interface IParser
    {
        void Parse(string input);
        string RequiredPrefix { get; }
        /* you'll want to add anything that's appropriate for your code here */
    }
    
    public class FcPortParser : IParser { ... }
    public class FcipPortParser : IParser { ... }
