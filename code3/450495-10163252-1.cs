       public static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                //populate grid view
            }
        }
        public static void Search(string number)
        {
            WebClient wClient = new WebClient();
            
            sNumber = number;
            int i = 0;
            DateTime datetime;
            wClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted); //this should be added in the constructor, so it would only be added once
            wClient.DownloadStringAsync(new Uri(sURL + sNumber));
         }
