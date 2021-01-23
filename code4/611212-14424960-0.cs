    abstract class Plugin
    {
      protected string Username;
      protected string Password;
    }
    
    class Imp : Plugin
    {
        public Imp()
        {
         	base.Username = "Taylor";
            base.Password = "Pass";
        }
    }
