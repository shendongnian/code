    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Threading;
    using System.Windows.Forms;
    
    /// <summary>
    /// Summary description for CustomBrowser
    /// </summary>
    public class CustomBrowser
    {
        public CustomBrowser()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    
        protected string _url;
        string html = "";
        public string GetWebpage(string url)
        {
            _url = url;
            // WebBrowser is an ActiveX control that must be run in a
            // single-threaded apartment so create a thread to create the
            // control and generate the thumbnail
            Thread thread = new Thread(new ThreadStart(GetWebPageWorker));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            string s = html;
            return s;
        }
    
        protected void GetWebPageWorker()
        {
            using (WebBrowser browser = new WebBrowser())
            {
                //  browser.ClientSize = new Size(_width, _height);
                browser.ScrollBarsEnabled = false;
                browser.ScriptErrorsSuppressed = true;
                browser.Navigate(_url);
    
                // Wait for control to load page
                while (browser.ReadyState != WebBrowserReadyState.Complete)
                    Application.DoEvents();
    
                html = browser.DocumentText;
    
            }
        }
    
    }
