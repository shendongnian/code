    public class Logger : IDisposable
{
    private string _logDirectory = null;
    private static Logger _instance = null;
    private Logger() : this(ConfigurationManager.AppSettings["LogDirectory"])
    {
        AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
    }
    
    private Logger(string logDirectory) 
    {
    } 
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Logger();
            return _instance;
        }
    }
    private void CurrentDomain_ProcessExit(object sender, EventArgs e)
    {
        Dispose();
    }
    public void Dispose()
    {
        // Dispose unmanaged resources
    }
