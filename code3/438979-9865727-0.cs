	WebClient wc = new WebClient();
			string fPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/myfile.xml";
			wc.DownloadFileCompleted += delegate(object sender, AsyncCompletedEventArgs e) {
		    	BasicOperations bas = new BasicOperations();
				
				//save results as file
				
				SavedJobs = bas.GetJobs(fPath);
				TableView.Source = new DataSource (this);
				TableView.ReloadData();
			};
			
			
			
			wc.DownloadFileAsync(new Uri(uString), fPath);
