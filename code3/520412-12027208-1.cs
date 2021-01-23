	public class MyClass
	{
		private void MyMethod()
		{
		  FindName();		
		}
		public void FindCityName()
        {
            string url = "http://maps.google.com/maps/geo?q=39.920794,32.853902&output=json&oe=utf8&sensor=true&key=MYKEY";
            var w = new WebClient();
            Observable.FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted").Subscribe(r =>
                {
                    var deserialized = JsonConvert.DeserializeObject<RootObject>(r.EventArgs.Result);
                    City = deserialized.Placemark[0].AddressDetails.Country.SubAdministrativeArea.Locality.LocalityName;
					DoneDownloading();
                });
            w.DownloadStringAsync(new Uri(url)); 
		}
		
		private string City;
		
		private void DoneDownloading
		{
		    MessageBox.Show(City);
	    }
	}
