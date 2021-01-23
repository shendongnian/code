    private void PushMe_Click(object sender, RoutedEventArgs e)
    		{
    			var scheduler = Scheduler.NewThread;
    			scheduler.Schedule(action => GetWeb());			
    			MessageBox.Show("This is a test.", "Test caption.", MessageBoxButton.OK);
    		}
    
    		private void GetWeb()
    		{
    			Thread.Sleep(3000);
    			var httpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.stackoverflow.com");
    			httpWebRequest.Method = "GET";
    
    			httpWebRequest.BeginGetResponse(BeginGetResponseCallback, httpWebRequest);
    		}
    
    		private void BeginGetResponseCallback(IAsyncResult ar)
    		{
    			
    		}
