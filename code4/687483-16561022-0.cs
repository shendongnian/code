    class myCustomResolver  : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (type == typeof(APIResultWidget))
            {
                switch ((string)dictionary["Type"])
                {
                    case "weather":
                        {
                            WeatherWidget x = new WeatherWidget();
                            x.Location = (string)dictionary["Location"];
                            x.Current = (CurrentWeather)dictionary["Current"];
                            //x.Forcast = (List<WeatherForcastItem>)dictionary["Forcast"];
                            System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Forcast"]);
                            foreach (var item in itemss)
                            {
                                x.Forcast.Add(serializer.ConvertToType<WeatherForcastItem>(item));
                            }
                            return x;
                        };
                    case "text":
                        {
                            TextWidget x = new TextWidget();
                            x.Content = (string)dictionary["Content"];
                            return x;
                        }; 
                    case "keyValueText":
                        {
                            KeyValueTextWidget x = new KeyValueTextWidget();
                            x.Key = (string)dictionary["Key"];
                            x.Key = (string)dictionary["Value"];
                            x.Key = (string)dictionary["ValueURL"];
                            return x;
                        };
                    case "keyValuesText":
                        {
                            KeyValuesTextWidget x = new KeyValuesTextWidget();
                            x.Key = (string)dictionary["Key"];
                            //x.Values = (List<ValueItem>)dictionary["ValueItem"];
                            System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["ValueItem"]);
                            foreach (var item in itemss)
                            {
                                x.Values.Add(serializer.ConvertToType<ValueItem>(item));
                            }
                            return x;
                        }; 
                    case "url":
                        {
                            URLWidget x = new URLWidget();
                            x.ThumbnailImageURL = (string)dictionary["ThumbnailImageURL"];
                            x.Title = (string)dictionary["Title"];
                            x.URL = (string)dictionary["URL"];
                            x.HTMLContent = (string)dictionary["HTMLContent"];
                            return x;
                        }; 
                    case "map":
                        {
                            MapWidget x = new MapWidget();
                            System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Pins"]);
                            foreach (var item in itemss)
                            {
                                x.Pins.Add(serializer.ConvertToType<MapPoint>(item));
                            }
                            //x.Pins = (List<MapPoint>)dictionary["Pins"];
                            return x;
                        }; 
                    case "image":
                        {
                            ImageWidget x = new ImageWidget();
                            x.Title = (string)dictionary["Title"];
                            x.ImageURL = (string)dictionary["ImageURL"];
                            x.ThumbnailURL = (string)dictionary["ThumbnailURL"];
                            x.PageURL = (string)dictionary["PageURL"];
                            return x;
                        }; 
                    case "html":
                        {
                            HTMLWidget x = new HTMLWidget();
                            x.Title = (string)dictionary["Title"];
                            x.HTML = (string)dictionary["HTML"];
                            return x;
                        }; 
                    case "entity":
                        {
                            EntityWidget x = new EntityWidget();
                            x.SubType = (string)dictionary["SubType"];
                            x.Title = (string)dictionary["Title"];
                            x.Abstract = (string)dictionary["Abstract"];
                            x.ImageURL = (string)dictionary["ImageURL"];
                            x.Url = (string)dictionary["Url"];
                            return x;
                        }; 
                    case "chart":
                        {
                            ChartWidget x = new ChartWidget();
                            x.Title = (string)dictionary["Title"];
                            //x.Categories = (List<string>)dictionary["Categories"];
                            System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Categories"]);
                            foreach (var item in itemss)
                            {
                                x.Categories.Add(serializer.ConvertToType<string>(item));
                            }
                            System.Collections.ArrayList itemss2 = ((System.Collections.ArrayList)dictionary["Data"]);
                            foreach (var item in itemss2)
                            {
                                x.Data.Add(serializer.ConvertToType<ChartsData>(item));
                            }
                            //x.Data = (List<ChartsData>)dictionary["Data"];
                            return x;
                        }; 
                    case "businessEntity":
                        {
                            BusinessEntityWidget x = new BusinessEntityWidget();
                            x.SubType = (string)dictionary["SubType"];
                            x.Title = (string)dictionary["Title"];
                            x.Abstract = (string)dictionary["Abstract"];
                            x.ImageURL = (string)dictionary["ImageURL"];
                            x.URL = (string)dictionary["URL"];
                            //x.Attributes = (List<KeyValueTextWidget>)dictionary["Attributes"];
                            System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Attributes"]);
                            foreach (var item in itemss)
                            {
                                x.Attributes.Add(serializer.ConvertToType<KeyValueTextWidget>(item));
                            }
                            x.Address = (string)dictionary["Address"];
                            x.Phone = (string)dictionary["Phone"];
                            x.Lat = (double)dictionary["Lat"];
                            x.Lng = (double)dictionary["Lng"];
                            System.Collections.ArrayList itemss2 = ((System.Collections.ArrayList)dictionary["OtherURLs"]);
                            foreach (var item in itemss2)
                            {
                                x.OtherURLs.Add(serializer.ConvertToType<URLWidget>(item));
                            }
                            //x.OtherURLs = (List<URLWidget>)dictionary["OtherURLs"];
                            return x;
                        }; 
                    case "list":
                        {
                            switch ((string)dictionary["SubType"])
                            {
                                case null:
                                    {
                                        ListWidget x = new ListWidget();
                                        x.Title = (string)dictionary["Title"];
                                        System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Items"]);
                                        foreach (var item in itemss)
                                        {
                                            x.Items.Add(serializer.ConvertToType<APIResultWidget>(item));
                                        }
                                        return x;
                                    }; 
                                case "videos":
                                    {
                                        ListOfVideosWidget x = new ListOfVideosWidget();
                                        System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Items"]);
                                        foreach (var item in itemss)
                                        {
                                            x.Items.Add(serializer.ConvertToType<URLWidget>(item));
                                        }
                                        return x;
                                    }; 
                                case "images":
                                    {
                                        ListOfImagesWidget x = new ListOfImagesWidget();
                                        System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Items"]);
                                        foreach (var item in itemss)
                                        {
                                            x.Items.Add(serializer.ConvertToType<ImageWidget>(item));
                                        }
                                        return x;
                                    }; 
                                case "webResults":
                                    {
                                        ListOfWebsitesWidget x = new ListOfWebsitesWidget();
                                        System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Items"]);
                                        foreach (var item in itemss)
                                        {
                                            x.Items.Add(serializer.ConvertToType<URLWidget>(item));
                                        }
                                        return x;
                                    }; 
                                case "businesses":
                                    {
                                        ListOfBusinessesWidget x = new ListOfBusinessesWidget();
                                        x.Title = (string)dictionary["Title"];
                                        System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["Items"]);
                                        foreach (var item in itemss)
                                        {
                                            x.Items.Add(serializer.ConvertToType<BusinessEntityWidget>(item));
                                        }
                                        return x;
                                    }; 
                            }
                        }; break;
                }
            }
            else //in case of objects not inheriting from the abstract class, in this case we identify each one by something else, not "type"
            {
                if (dictionary.ContainsKey("Day")) //WeatherForcastItem
                {
                    WeatherForcastItem x = new WeatherForcastItem();
                    x.Day = (string)dictionary["Day"];
                    x.Hi = (string)dictionary["Hi"];
                    x.Lo = (string)dictionary["Lo"];
                    x.Status = (string)dictionary["Status"];
                    x.IconURL = (string)dictionary["IconURL"];
                    return x;
 
                }
                else if (dictionary.ContainsKey("Temprature")) // CurrentWeather
                {
                    CurrentWeather x = new CurrentWeather();
                    x.Temprature = (string)dictionary["Temprature"];
                    x.Status = (string)dictionary["Status"];
                    x.WindSpeed = (string)dictionary["WindSpeed"];
                    x.WindDirection = (string)dictionary["WindDirection"];
                    x.Humidity = (string)dictionary["Humidity"];
                    x.IconURL = (string)dictionary["IconURL"];
                    x.IsNight = (string)dictionary["IsNight"];
                    return x;
                }
                else if (dictionary.ContainsKey("Lat")) //MapPoint
                {
                    MapPoint x = new MapPoint();
                    x.Title = (string)dictionary["Title"];
                    x.Lat = (double)dictionary["Lat"];
                    x.Lng = (double)dictionary["Lng"];
                    return x;
                }
                else if (dictionary.ContainsKey("Value")) //ValueItem
                {
                    ValueItem x = new ValueItem();
                    x.Value = (string)dictionary["Value"];
                    x.ValueURL = (string)dictionary["ValueURL"];
                    return x;
                }
                else if (dictionary.ContainsKey("name")) //ChartsData
                {
                    ChartsData x = new ChartsData();
                    x.name = (string)dictionary["name"];
                    System.Collections.ArrayList itemss = ((System.Collections.ArrayList)dictionary["name"]);
                    foreach (var item in itemss)
                    {
                        x.values.Add(serializer.ConvertToType<string>(item));
                    }
                    return x;
                }
            }
            return null;
        }
        public override IDictionary<string, object> Serialize(
     object obj,
     JavaScriptSerializer serializer)
        { return null; }
        private static readonly Type[] _supportedTypes = new[]
    {
        typeof( APIResultWidget )
    };
        public override IEnumerable<Type> SupportedTypes
        {
            get { return _supportedTypes; }
        }
    }
