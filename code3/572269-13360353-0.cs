    public void AddtoFavorite(Flight FavoriteFlight)
    {
            try
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
    
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Favorite.xml", FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Flight));
                        using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                        {
                            FavoriteFlight.SavedDate = DateTime.Now;
                            serializer.Serialize(xmlWriter, FavoriteFlight);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
    
            }    
     }
    public FavoriteFlight GetFavorite()
    {
            FavoriteFlight result = new FavoriteFlight();
            result.VisibleFavorite = false;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Favorite.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Flight));
                       Flight fav=(Flight)serializer.Deserialize(stream);
                       if ((DateTime.Now - fav.SavedDate).TotalHours > 24)
                       {
                           // TODO: Refresh the value
                       }
                       result.FlightFavorite = fav;
                       result.Date = result.FlightFavorite.ArrivalOrDepartDateTime.ToString("dd/MM/yyyy");
                       result.VisibleFavorite = true;
                       return result;
    
                    }
                }    
            }
            catch
            {
                return result;
            }
    
    }
