    public void SaveToDisk()
            {           
                 if (Windows.Storage.ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
                    {
                        if (Windows.Storage.ApplicationData.Current.LocalSettings.Values[key].ToString() != null)
                        { 
                            //do update
                            Windows.Storage.ApplicationData.Current.LocalSettings.Values[key] = value;
                        }
                    }
                 else 
                    {   // do create key and save value, first time only.
    
                        Windows.Storage.ApplicationData.Current.LocalSettings.CreateContainer(key, ApplicationDataCreateDisposition.Always);
                        if (Windows.Storage.ApplicationData.Current.LocalSettings.Values[key] == null)
                        {
                            Windows.Storage.ApplicationData.Current.LocalSettings.Values[key] = value;
                        }
    
                     using (StreamWriter writer = new StreamWriter(stream))
                        {
                            List<SquareViewModel> s = new List<SquareViewModel>();
                            foreach (SquareViewModel item in GameArray)
                                s.Add(item);
    
                            XmlSerializer serializer = new XmlSerializer(s.GetType());
                            serializer.Serialize(writer, s);
                        }
                     }                
                
            }
