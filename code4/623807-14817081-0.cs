    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Globalization;
    using System.Net;
    using System.Security.Principal;
    using System.Text;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Security;
    
    namespace MySecurity
    {
        public class BasicAuthenticationModule : IHttpModule
        {
            public event EventHandler<BasicAuthenticationEventArgs> Authenticate;
    
            public void Dispose()
            {
            }
    
            protected virtual string GetRealm(HttpContext context)
            {
                return BasicAuthenticationSection.Current.GetRealm(context);
            }
    
            public virtual void Init(HttpApplication context)
            {
                context.AuthenticateRequest += OnAuthenticateRequest;
                context.EndRequest += OnEndRequest;
            }
    
            protected virtual bool FormsAuthenticate(HttpContext context, string login, string password, string realm)
            {
                // check ad-hoc forms credentials, as we can support it even if forms auth is not configured
                FormsAuthenticationConfiguration c = ((AuthenticationSection)ConfigurationManager.GetSection("system.web/authentication")).Forms;
                if ((c.Credentials == null) || (c.Credentials.Users == null))
                    return false;
    
                foreach (FormsAuthenticationUser user in c.Credentials.Users)
                {
                    if ((string.Compare(user.Name, login, true, CultureInfo.CurrentCulture) == 0) &&
                        (string.Compare(user.Password, password, true, CultureInfo.CurrentCulture) == 0))
                        return true;
                }
                return false;
            }
    
            protected virtual bool OnAuthenticate(HttpContext context, string login, string password, string realm)
            {
                EventHandler<BasicAuthenticationEventArgs> handler = Authenticate;
                if (handler != null)
                {
                    BasicAuthenticationEventArgs e = new BasicAuthenticationEventArgs(context, login, password, realm);
                    handler(this, e);
                    return !e.Cancel;
                }
                return FormsAuthenticate(context, login, password, realm);
            }
    
            protected virtual string[] GetUserRoles(HttpContext context, string login, string realm)
            {
                // TODO: overwrite if needed
                return new string[0];
            }
    
            protected virtual IPrincipal GetUser(HttpContext context, FormsAuthenticationTicket ticket)
            {
                return new GenericPrincipal(new BasicAuthenticationIdentity(ticket), GetUserRoles(context, ticket.Name, GetRealm(context)));
            }
    
            protected virtual void OnAuthenticated(HttpContext context)
            {
            }
    
            protected virtual void OnEndRequest(object sender, EventArgs e)
            {
                HttpApplication application = (HttpApplication)sender;
                if (application.Response.StatusCode != (int)HttpStatusCode.Unauthorized)
                    return;
    
                string basic = "Basic Realm=\"" + GetRealm(application.Context) + "\"";
                application.Response.AppendHeader("WWW-Authenticate", basic);
            }
    
            public static void SignOut()
            {
                if (HttpContext.Current == null)
                    return;
    
                HttpContext.Current.Request.Cookies.Remove(BasicAuthenticationSection.Current.Name);
                HttpContext.Current.Response.Cookies.Remove(BasicAuthenticationSection.Current.Name);
                HttpCookie cookie = new HttpCookie(BasicAuthenticationSection.Current.Name);
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
    
            public static bool IsAuthenticated(HttpContext context)
            {
                if ((context == null) || (context.User == null) || (context.User.Identity == null))
                    return false;
    
                return context.User.Identity.IsAuthenticated;
            }
    
            protected virtual void OnAuthenticateRequest(object sender, EventArgs e)
            {
                HttpApplication application = (HttpApplication)sender;
                if ((IsAuthenticated(application.Context)) && (!BasicAuthenticationSection.Current.ReAuthenticate))
                    return;
    
                string encryptedTicket;
                FormsAuthenticationTicket ticket;
                HttpCookie cookie = application.Context.Request.Cookies[BasicAuthenticationSection.Current.Name];
                if (cookie == null)
                {
                    // no cookie, check auth header
                    string authHeader = application.Context.Request.Headers["Authorization"];
                    if ((string.IsNullOrEmpty(authHeader)) || (!authHeader.StartsWith("Basic ", StringComparison.InvariantCultureIgnoreCase)))
                    {
                        ResponseAccessDenied(application);
                        return;
                    }
    
                    string login;
                    string password;
                    string lp = authHeader.Substring(6).Trim();
                    if (string.IsNullOrEmpty(lp))
                    {
                        ResponseAccessDenied(application);
                        return;
                    }
    
                    lp = Encoding.Default.GetString(Convert.FromBase64String(lp));
                    if (string.IsNullOrEmpty(lp.Trim()))
                    {
                        ResponseAccessDenied(application);
                        return;
                    }
    
                    int pos = lp.IndexOf(':');
                    if (pos < 0)
                    {
                        login = lp;
                        password = string.Empty;
                    }
                    else
                    {
                        login = lp.Substring(0, pos).Trim();
                        password = lp.Substring(pos + 1).Trim();
                    }
    
                    if (!OnAuthenticate(application.Context, login, password, GetRealm(application.Context)))
                    {
                        ResponseAccessDenied(application);
                        return;
                    }
    
                    // send cookie back to client
                    ticket = new FormsAuthenticationTicket(login, false, (int)BasicAuthenticationSection.Current.Timeout.TotalMinutes);
                    encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    cookie = new HttpCookie(BasicAuthenticationSection.Current.Name, encryptedTicket);
                    application.Context.Response.Cookies.Add(cookie);
    
                    // don't overwrite context user if it's been set
                    if ((!IsAuthenticated(application.Context)) || (BasicAuthenticationSection.Current.ReAuthenticate))
                    {
                        application.Context.User = GetUser(application.Context, ticket);
                    }
                    OnAuthenticated(application.Context);
                    application.Context.Response.StatusCode = (int)HttpStatusCode.OK;
                    return;
                }
    
                // there is a cookie, check it
                encryptedTicket = cookie.Value;
                if (string.IsNullOrEmpty(encryptedTicket))
                {
                    ResponseAccessDenied(application);
                    return;
                }
    
                try
                {
                    ticket = FormsAuthentication.Decrypt(encryptedTicket);
                }
                catch
                {
                    ResponseAccessDenied(application);
                    return;
                }
    
                if (ticket.Expired)
                {
                    ResponseAccessDenied(application);
                    return;
                }
    
                // set context user
                // don't overwrite context user if it's been set
                if ((!IsAuthenticated(application.Context) || (BasicAuthenticationSection.Current.ReAuthenticate)))
                {
                    application.Context.User = GetUser(application.Context, ticket);
                }
                OnAuthenticated(application.Context);
            }
    
            protected virtual void WriteAccessDenied(HttpApplication application)
            {
                if (application == null)
                    throw new ArgumentNullException("application");
    
                application.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                application.Context.Response.StatusDescription = "Unauthorized";
                application.Context.Response.Write(application.Context.Response.StatusCode + " " + application.Context.Response.StatusDescription);
            }
    
            protected virtual void ResponseAccessDenied(HttpApplication application)
            {
                // if there is a bad cookie, kill it
                application.Context.Request.Cookies.Remove(BasicAuthenticationSection.Current.Name);
                application.Context.Response.Cookies.Remove(BasicAuthenticationSection.Current.Name);
                HttpCookie cookie = new HttpCookie(BasicAuthenticationSection.Current.Name);
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
                WriteAccessDenied(application);
                application.CompleteRequest();
            }
        }
    
        public class BasicAuthenticationSection : ConfigurationSection
        {
            public const string SectionName = "basicAuth";
            private const string DefaultCookieName = "." + SectionName;
            private static BasicAuthenticationSection _current;
    
            public static BasicAuthenticationSection Current
            {
                get
                {
                    return _current ?? (_current = ConfigurationManager.GetSection(SectionName) as BasicAuthenticationSection ?? new BasicAuthenticationSection());
                }
            }
    
            [StringValidator(MinLength = 1), ConfigurationProperty("name", DefaultValue = DefaultCookieName)]
            public string Name
            {
                get
                {
                    return (string)base["name"];
                }
            }
    
            internal string GetRealm(HttpContext context)
            {
                if (!string.IsNullOrEmpty(Realm))
                    return Realm;
    
                return context.Request.Url.Host;
            }
    
            [ConfigurationProperty("realm", DefaultValue = "")]
            public string Realm
            {
                get
                {
                    return (string)base["realm"];
                }
            }
    
            [ConfigurationProperty("domain", DefaultValue = "")]
            public string Domain
            {
                get
                {
                    return (string)base["domain"];
                }
            }
    
            [ConfigurationProperty("reAuthenticate", DefaultValue = false)]
            public bool ReAuthenticate
            {
                get
                {
                    return (bool)base["reAuthenticate"];
                }
            }
    
            [TypeConverter(typeof(TimeSpanMinutesConverter)), ConfigurationProperty("timeout", DefaultValue = "30"), PositiveTimeSpanValidator]
            public TimeSpan Timeout
            {
                get
                {
                    return (TimeSpan)base["timeout"];
                }
            }
        }
    
        public class BasicAuthenticationIdentity : IIdentity
        {
            public BasicAuthenticationIdentity(FormsAuthenticationTicket ticket)
            {
                if (ticket == null)
                    throw new ArgumentNullException("ticket");
    
                Ticket = ticket;
            }
    
            public FormsAuthenticationTicket Ticket;
    
            public string AuthenticationType
            {
                get
                {
                    return BasicAuthenticationSection.SectionName;
                }
            }
    
            public bool IsAuthenticated
            {
                get
                {
                    return true;
                }
            }
    
            public string Name
            {
                get
                {
                    return Ticket.Name;
                }
            }
        }
    
        public class BasicAuthenticationEventArgs : CancelEventArgs
        {
            public BasicAuthenticationEventArgs(HttpContext context, string login, string password, string realm)
            {
                if (context == null)
                    throw new ArgumentNullException("context");
    
                Context = context;
                Login = login;
                Password = password;
                Realm = realm;
            }
    
            public HttpContext Context { get; private set; }
            public string Realm { get; private set; }
            public string Login { get; private set; }
            public string Password { get; private set; }
            public IPrincipal User { get; set; }
        }
    }
