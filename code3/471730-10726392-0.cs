    public static DayOfWeek Wunderground(string zip)
        {
            //Insert your API key in the below URL
            string latlong = "37.8,-122.4";
            string url = "http://api.wunderground.com/api/*insertyourapikeyhere*/geolookup/conditions/forecast/q/"+latlong+".xml";
            
            HttpWebRequest web = (HttpWebRequest)WebRequest.Create(url);
            web.UseDefaultCredentials = true;
            web.PreAuthenticate = true;
            web.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.168 Safari/535.19";
            web.GetResponse();
            //Get Dopplar Image
            var dop = "http://api.wunderground.com/api/7dca468f5dd2ff1b/animatedradar/q/TX/Houston.gif?newmaps=1&timelabel=1&width=640&height=480&timelabel.y=10&num=15&delay=50";
            WebClient wc = new WebClient();
            wc.DownloadFile(dop, "dop.gif");
                        
            //Prepare my custom property
            var d = new WeatherLib.DayOfWeek();
            d.Current = new WDay();
            WDay forecast = new WDay();
            var conditions = d;
            var xmlConditions = new XmlDocument();
            
            //download the api xml
            XDocument api = XDocument.Load(url);
            api.Save("api.xml");
            xmlConditions.Load(string.Format(@"api.xml"));
            XmlNodeList list = xmlConditions.SelectNodes("/response/current_observation");
            WDay current = d.Current;
            
            //Parse out the XML data
            foreach (XmlNode node in list)
            {
                current.WeatherText = node.SelectSingleNode("weather").InnerText;
                current.TempCurrentF = node.SelectSingleNode("temp_f").InnerText;
                current.TempCurrentC = node.SelectSingleNode("temp_c").InnerText;
                current.Humidity = node.SelectSingleNode("relative_humidity").InnerText;
                current.WindDirection = node.SelectSingleNode("wind_dir").InnerText;
                current.WindSpeedM = node.SelectSingleNode("wind_mph").InnerText;
                current.WindSpeedK = node.SelectSingleNode("wind_kph").InnerText;
                current.Barometer = node.SelectSingleNode("pressure_mb").InnerText;
                current.HeatIndexF = node.SelectSingleNode("heat_index_f").InnerText;
                current.HeatIndexC = node.SelectSingleNode("heat_index_c").InnerText;
                current.WindChill = node.SelectSingleNode("windchill_string").InnerText;
                current.UVIndex = node.SelectSingleNode("UV").InnerText;
                current.RainAmount = node.SelectSingleNode("precip_today_in").InnerText;
                current.Visibility = node.SelectSingleNode("visibility_mi").InnerText;
                current.DewPoint = node.SelectSingleNode("dewpoint_f").InnerText;
                
                
            }return d;
        }
