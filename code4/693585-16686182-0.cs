    using System;
    using System.Collections.Generic;
    using System.Web;
    
    /// <summary>
    /// Summary description for SiteSession
    /// </summary>
    public class SiteSession
    {
        /// <summary>
        /// The _site session
        /// </summary>
        private const string _siteSession = "__SiteSession__";
    
    
        /// <summary>
        /// Prevents a default instance of the <see cref="SiteSession" /> class from being created.
        /// </summary>
        private SiteSession()
        {
        }
    
        /// <summary>
        /// Gets the current Session
        /// </summary>
        /// <value>The current.</value>
        public static SiteSession Current
        {
            get
            {
                SiteSession session = new SiteSession();
                try
                {
                    session = HttpContext.Current.Session[_siteSession] as SiteSession;
                }
                catch(NullReferenceException asp)
                {
                    
                }
    
                if (session == null)
                {
                    session = new SiteSession();
                    HttpContext.Current.Session[_siteSession] = session;
                }
                return session;
            }
        }
        
        //Session properties
        public int PageNumber {get;set;}
        
    }
