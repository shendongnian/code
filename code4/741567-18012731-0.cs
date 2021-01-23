    public interface ISessionValueProvider {
    	string CurrentUser { get; set; }
    	string CurrentDatabase { get; set; }
    	string CurrentCompanyProfile { get; set; }
    	string CurrentLanguage { get; set; }
    }
    
    public static class Session {
    	private static ISessionValueProvider _sessionValueProvider;
    	public static void SetSessionValueProvider(ISessionValueProvider provider) {
    		_sessionValueProvider = provider;
    	}
    	
        public static string CurrentUser { 
    		get { return _sessionValueProvider.CurrentUser; } 
    		set { _sessionValueProvider.CurrentUser = value; } 
    	}
    	// Etc for the other props
    }
