    public class MyApplication : WindowsFormsApplicationBase
    {
    	private static MyApplication _application;
    
    	public static void Run(Form form)
    	{
    		_application = new MyApplication{ MainForm = form };
    		_application.Run(Environment.GetCommandLineArgs());
    	}
    
    	protected override void OnCreateSplashScreen()
    	{
    		this.SplashScreen = new MySplashScreenForm();
    	}
    }
