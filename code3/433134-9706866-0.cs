           DateTime start = DateTime.Now;
           string[] splitProxy = ProxyList[i].Split('|');
           string testResults 
                = HTMLProcessor.HTMLProcessing.HTMLResults("http://www.google.com", 
                splitProxy[0], Convert.ToInt32(splitProxy[1]), true, out testResults);
           ProxyListResults.Add(ProxyList+"|"+proxyStopWatch.Interval.ToString());
           Console.WriteLine("Time elapsed in milliseconds was: " 
                + (DateTime.Now - start).TotalMilliseconds);
