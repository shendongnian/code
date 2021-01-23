    using System;
    using DotNetBrowser;
    
    namespace MyNamespace
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create Browser instance.
                Browser browser = BrowserFactory.Create();
                browser.LoadURL("http://www.google.com");
            }
        }
    }
