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
            wClient.DownloadStringAsync(new Uri(sURL + sNumber));
            wClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
         }
