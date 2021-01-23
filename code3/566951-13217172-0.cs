    ProcessStartInfo psiOjbect = new ProcessStartInfo("http://DefaultWebsiteOfmyCompany.com"); // You can also use "about:blank".
    
                BrowserProcess.StartInfo = psiOjbect;
                BrowserProcess.Start();
                Thread.Sleep(1000); //Need to wait 
    
                foreach (string websiteUrl in Properties.Settings.Default.WebSiteURLs)
                {
                    Process.Start(websiteUrl );
                }
