    public static DayOfWeek Google(string zip)
        {
            string urlstring = "http://www.google.com/ig/api?weather="+zip;
            var d = new WeatherLib.DayOfWeek();
            d.Monday = new WDay();
            d.Tuesday = new WDay();
            d.Wednesday = new WDay();
            d.Thursday = new WDay();
            d.Friday = new WDay();
            d.Saturday = new WDay();
            d.Sunday = new WDay();
            d.Current = new WDay();
            WDay forecast = new WDay();
            var conditions = d;
            var xmlConditions = new XmlDocument();
            XDocument api = XDocument.Load(urlstring);
            api.Save("api.xml");
            xmlConditions.Load(string.Format(@"api.xml"));
            if (xmlConditions.SelectSingleNode("xml_api_reply/weather/problem_cause") != null)
            {
                conditions = null;
            }
            else
            {
                
                var singleNode = xmlConditions.SelectSingleNode("xml_api_reply/weather/current_conditions/condition");
                if (singleNode != null)
                    if (singleNode.Attributes != null)
                        conditions.Current.WeatherText =
                            singleNode.Attributes[
                                "data"].InnerText;
                var node = xmlConditions.SelectSingleNode("xml_api_reply/weather/current_conditions/temp_c");
                if (node != null)
                    if (node.Attributes != null)
                        conditions.Current.TempCurrentC =
                            node.Attributes["data"]
                                .InnerText;
                var selectSingleNode1 = xmlConditions.SelectSingleNode("xml_api_reply/weather/current_conditions/temp_f");
                if (selectSingleNode1 != null)
                    if (selectSingleNode1.Attributes != null)
                        conditions.Current.TempCurrentF =
                            selectSingleNode1.Attributes["data"]
                                .InnerText;
                var singleNode1 = xmlConditions.SelectSingleNode("xml_api_reply/weather/current_conditions/humidity");
                if (singleNode1 != null)
                    if (singleNode1.Attributes != null)
                        conditions.Current.Humidity =
                            singleNode1.Attributes[
                                "data"].InnerText;
                var xmlNode1 = xmlConditions.SelectSingleNode("xml_api_reply/weather/current_conditions/wind_condition");
                if (xmlNode1 != null)
                    if (xmlNode1.Attributes != null)
                        conditions.Current.WindSpeedM =
                            xmlNode1.Attributes
                                ["data"].InnerText;
                if (xmlConditions.SelectSingleNode("xml_api_reply/weather/problem_cause") != null)
                {
                    conditions = null;
                }
                else
                {
                    XmlNodeList list = xmlConditions.SelectNodes("/xml_api_reply/weather");
                    foreach(XmlNode node1 in list)
                    {
                        XmlNodeList days = node1.SelectNodes("forecast_conditions");
                        foreach (XmlNode doo in days)
                        {
                            string dow = doo.SelectSingleNode("day_of_week").Attributes["data"].InnerText;
                            switch (dow)
                            {
                                case "Mon":
                                    forecast = d.Monday;
                                    break;
                                case "Tue":
                                    forecast = d.Tuesday;
                                    break;
                                case "Wed":
                                    forecast = d.Wednesday;
                                    break;
                                case "Thu":
                                    forecast = d.Thursday;
                                    break;
                                case "Fri":
                                    forecast = d.Friday;
                                    break;
                                case "Sat":
                                    forecast = d.Saturday;
                                    break;
                                case "Sun":
                                    forecast = d.Sunday;
                                    break;
                            }
                            forecast.WeatherText = doo.SelectSingleNode("condition").Attributes["data"].InnerText;
                            forecast.TempHiF = doo.SelectSingleNode("high").Attributes["data"].InnerText;                         
                        }
                    }       
                }
                }
