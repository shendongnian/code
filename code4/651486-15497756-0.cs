     foreach (string key in Configuration.AppSettings.Settings.AllKeys)
            {
                string value = appSettings.Settings[key].Value;
                if (value.Equals(myValue))
                {
                     Console.WriteLine("Found Key: " + key);
                     break;
                }
            }
