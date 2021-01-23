        private void Save()
        {
            Collection<MyAppSettings> myAppSettings = new Collection<MyAppSettings>();
            myAppSettings.Add(new MyAppSettings
            {
                Foo = new DateTimeOffset(2012, 12, 12, 12, 12, 12, TimeSpan.Zero),
                Bar = new DateTimeOffset(2011, 11, 11, 11, 11, 11, TimeSpan.Zero)
            });
            IsolatedStorageSettings.ApplicationSettings["MyAppSettings"] = myAppSettings;
        }
        
        private void Load()
        {
            Collection<MyAppSettings> myAppSettings = (Collection<MyAppSettings>)IsolatedStorageSettings.ApplicationSettings["MyAppSettings"];
            string foo = myAppSettings.First().Foo.ToString();
            string bar = myAppSettings.First().Bar.ToString();
        }
        
