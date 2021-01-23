        namespace MySettings.Providers
        {
            Dictionary<string, object> _mySettings;
            class MySettingsProvider : SettingsProvider
            {
                // Implement the constructor, override Name, Initialize, 
                // ApplicationName, SetPropertyValues and GetPropertyValues (see step 3 below)
                // 
                // In the constructor, you probably might want to initialize the _mySettings 
                // dictionary and load the custom configuration into it.
                // Probably you don't want make calls to the database each time
                // you want to read a setting's value
            }
        }
