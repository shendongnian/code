    //Defined in Dll appshared.dll    
    public static class MyApplication
    {
        static AppSession appSession = new AppSession();
        public interface IAppSession
        {
            Object this[string key]
            {
                get;
                set;
            }
        };
        sealed class AppSession : IAppSession
        {
            
            Dictionary<String, Object> _session = new Dictionary<string, object>();
            public AppSession()
            {
            }
            public Object this[string key]
            {
                get
                {
                    Object ret = null;
                    lock (_session)
                    {
                        _session.TryGetValue(key, out ret);
                    }
                    return ret;
                }
                set
                {
                    if (key == null)
                        throw new ArgumentNullException();
                    try
                    {
                        lock (_session)
                        {
                            if (value != null)
                                _session[key] = value;
                            else
                                _session.Remove(key);
                        }
                    }
                    catch (Exception eX)
                    {
                    }
                }
            }
        };
        public static IAppSession Session
        {
            get
            {
                return appSession;
            }
        }
    };
