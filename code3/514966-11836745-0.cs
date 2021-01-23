    public class RegistrationConfig {
       // private static instance
       private static RegistrationConfig _instance = new RegistrationConfig()
       // private constructor prevents the class from being instantiated from outside
       private RegistrationConfig() { }
       // instance public accessor
       public static RegistrationConfig Current { get { return _instance; } }
       public int InvitationToken { get; set; }
       public int InvitationDollar { get;set; }
    }
