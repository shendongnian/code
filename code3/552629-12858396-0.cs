        private void analyticsmethod4(string trackingId, string pagename)
		{
			Random rnd = new Random();
			long timestampFirstRun, timestampLastRun, timestampCurrentRun, numberOfRuns;
			// Get the first run time
			timestampFirstRun = DateTime.Now.Ticks;
			timestampLastRun = DateTime.Now.Ticks-5;
			timestampCurrentRun = 45;
			numberOfRuns = 2;
			// Some values we need
			string domainHash = "123456789"; // This can be calcualted for your domain online
			int uniqueVisitorId = rnd.Next(100000000, 999999999); // Random
			string source = "Shop159";
			string medium = "medium123";
			string sessionNumber = "1";
			string campaignNumber = "1";
			string culture = Thread.CurrentThread.CurrentCulture.Name;
			string screenRes = Screen.PrimaryScreen.Bounds.Width + "x" + Screen.PrimaryScreen.Bounds.Height;
			string statsRequest = "http://www.google-analytics.com/__utm.gif" +
				"?utmwv=4.6.5" +
				"&utmn=" + rnd.Next(100000000, 999999999) +
			//	"&utmhn=hostname.mydomain.com" +
				"&utmcs=-" +
				"&utmsr=" + screenRes +
				"&utmsc=-" +
				"&utmul=" + culture +
				"&utmje=-" +
				"&utmfl=-" +
				"&utmdt=" + pagename +
				"&utmhid=1943799692" +
				"&utmr=0" +
				"&utmp=" + pagename +
				"&utmac=" +trackingId+ // Account number
				"&utmcc=" +
					"__utma%3D" + domainHash + "." + uniqueVisitorId + "." + timestampFirstRun + "." + timestampLastRun + "." + timestampCurrentRun + "." + numberOfRuns +
					"%3B%2B__utmz%3D" + domainHash + "." + timestampCurrentRun + "." + sessionNumber + "." + campaignNumber + ".utmcsr%3D" + source + "%7Cutmccn%3D(" + medium + ")%7Cutmcmd%3D" + medium + "%7Cutmcct%3D%2Fd31AaOM%3B";
			using (var client = new WebClient())
			{
				client.DownloadData(statsRequest);
				//Stream data = client.OpenRead(statsRequest);
				//StreamReader reader = new StreamReader(data);
				//string s = reader.ReadToEnd();
			}
		}
