    public class RegistrationConfig {
       // current
       private static RegistrationConfig _current;
       // instance public accessor
       public static RegistrationConfig Current { get { return _current; } }
       // public setter
       public static void SetCurrent(RegistrationConfig current)
       {
           _current = current;
       }
       public int InvitationToken { get; set; }
       public int InvitationDollar { get;set; }
    }
