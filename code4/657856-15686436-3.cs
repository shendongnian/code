	public sealed class Settings
	{
		private static readonly Settings instance = new Settings();
        
	    public LoggerSettings Logger { get; private set; }
        public MailerSettings Mailer { get; private set; }
		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static Settings()
		{
		}
		private Settings()
		{
		   Logger = new LoggerSettings();
           Mailer = new MailerSettings();
		}
		public static Settings Instance { get { return instance;} }
	}
    public class LoggerSettings {
    
        public LoggerSettings()
        {
            Levels = ConfigurationManager.AppSettings["Logger.Levels"];
        }
        public String Levels { get; private set; }
        public const String Report = "team@xyz.com";
    
    }
    // Mailer settings would look similar
