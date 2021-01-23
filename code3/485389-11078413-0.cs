    public class LanguageModule : IHttpModule
    {
        public void Dispose()
        {
        }
    
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }
    
        void context_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var context = application.Context;
            var lang = context.Request.Headers["Accept-Language"];
    
            // eat the cookie (if any) and set the culture
            if (!string.IsNullOrEmpty(lang))
            {
                var culture = new System.Globalization.CultureInfo(lang); // you may need to interpret the value of "lang" to match what is expected by CultureInfo
    
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }
    }
