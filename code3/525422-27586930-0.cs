            Console.WriteLine(timesToRun.ToString());
            string currentSite = siteList.GetSiteFromIndex(timesToRun);
            webBrowser1.Document.Window.Navigate(currentSite);
            //I think I need to wait here until the document is ready
            //this line of code doesn't run on timeToRun = 22
            forumAction.FillOutFormIn(webBrowser1.Document);
            Console.WriteLine(webBrowser1.Url);
            timerLabel1.Text = siteList.SiteLists.Count + ">" + timesToRun + "";
            if (timesToRun >= siteList.SiteLists.Count - 1)
            {
                enableControls(true);
                timesToRun = 0;
                timer.Stop();
                Console.WriteLine("done");
            }
            timesToRun++;          
    }
