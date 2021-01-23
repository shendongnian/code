    private void btnSave_Click(object sender, RoutedEventArgs e)
    		{
    			SaveStringObject();
    			SaveCompositeObject();
    		}
    
    private void btnGet_Click(object sender, RoutedEventArgs e)
    		{
    			if(settings.Contains("myemail"))
    			{
    				//Retrieve email Data
    				var location = settings["myemail"].ToString();
    				settings["email"] = "support@windowsphonnegeek.com";
    			}
    
    			//Retrieve City Data
    			City City1;
    			settings.TryGetValue<City>("city", out City1);
    
    			this.DataContext = City1;
    		}
    
    public void SaveStringObject()
    		{
    			var settings = IsolatedStorageSettings.ApplicationSettings;
    			settings.Add("myemail", "support@windowsphonnegeek.com");
    		}
    
    		public void SaveCompositeObject()
    		{
    			var settings = IsolatedStorageSettings.ApplicationSettings;
    			City city = new City { Name = "London", Flag = "UK.png" };
    			settings.Add("city", city);
    		}
    
    		public class City
    		{
    			public string Name
    			{
    				get;
    				set;
    			}
    
    			public string Flag
    			{
    				get;
    				set;
    			}
    		}
