     // Supply the path to the Browsermob Proxy batch file
            Server server =
                new Server(
                    @"path\to\browsermob-proxy.bat");
            server.Start();
            Client client = server.CreateProxy();
            client.RemapHost("host", "ip address");
            client.NewHar("google");
            var seleniumProxy = new Proxy { HttpProxy = client.SeleniumProxy };
            var profile = new FirefoxProfile();
            profile.SetProxyPreferences(seleniumProxy);
            // Navigate to the page to retrieve performance stats for
            var driver = new FirefoxDriver(profile);
            driver.Navigate().GoToUrl("http://google.com.vn");
            
            // Get the performance stats
            HarResult harData = client.GetHar();
            AutomatedTester.BrowserMob.HAR.Log log = harData.Log;
            AutomatedTester.BrowserMob.HAR.Entry[] entries = log.Entries;
            foreach (var entry in entries)
            {
                AutomatedTester.BrowserMob.HAR.Request request = entry.Request;
                var url = request.Url;
                var time = entry.Time;
                Console.WriteLine("Url: " + url + " - Time: " + time);
            }
            driver.Quit();
            client.Close();
            server.Stop();
