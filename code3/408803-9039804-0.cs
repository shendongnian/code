    public sealed class ConfigurationAttribute : Attribute {
    
    }
    
    
    [ConfigurationAttribute]
    public class AnotherProblemConfiguration : IConfiguration 
    { 
        // other stuff 
    } 
