    abstract class Plugin
    {
       protected string Username;
    }
    class Imp : Plugin
    {
      public Imp()
      {
          this.Username = "Taylor"; // No error here...
      }
    }
