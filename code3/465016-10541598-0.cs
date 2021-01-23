        private void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }        
            XDocument xmlEntries = XDocument.Parse(e.Result); 
            IEnumerable<Driver> list = from item in feed.Descendants("channel").Elements("Driver")
                                           select new Driver
                                           {
                                               Name = (string)item.Attribute("driverId")                                              
                                           };
            ObservableCollection<Driver>() collection = new ObservableCollection<Driver>();
            foreach (Driver d in list)
            {
                collection.Add(d);
            }
          
            DriverListBox.ItemsSource = collection;
        }
