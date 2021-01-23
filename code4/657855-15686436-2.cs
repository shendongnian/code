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
		   // Logger = read all Logger settings here from config file
           // Mailer = read all Mailer settings here from config file
		}
		public static Settings Instance { get { return instance;} }
	}
