    public class SessionVar
    {
        HttpContextWrapper m_httpContext;
    
        public SessionVar(HttpContextWrapper httpContext = null)
        {
            m_httpContext = httpContext ?? new HttpContextWrapper(HttpContext.Current);
        }
        
        /// <summary>
        /// Gets the session.
        /// </summary>
        private HttpSessionState Session
        {
            get
            {
                if (m_httpContext == null)
                    throw new ApplicationException("No Http Context, No Session to Get!");
    
                return m_httpContext.Session;
            }
        }
    
        public T Get<T>(string key)
        {
            return Session[key] == null ? default(T) : (T)Session[key];
        }
        ...
    }
