    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    
    namespace CNGS
    {
        public class WeatherReader
        {
            public int Temp;
            public string Humidity;
            public string Wind;
            public string place;
    
            public void PopulateWeatherData()
            {
                XmlReader reader = XmlReader.Create("http://api.wunderground.com/api/adaebe40743a9ca6/geolookup/conditions/forecast/q/India/Pilani.xml");
    
                bool IsNextTemp = false;
                bool IsHumidityTemp = false;
                bool IsWindTemp = false;
    
                reader.MoveToContent();
    
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            if (reader.Name == "temp_c")
                            {
                                IsHumidityTemp = false;
                                IsWindTemp = false;
                                IsNextTemp = true;
                            }
                            else if (reader.Name == "relative_humidity")
                            {
                                IsHumidityTemp = true;
                                IsWindTemp = false;
                                IsNextTemp = false;
                            }
                            else if (reader.Name == "wind_string")
                            {
                                IsHumidityTemp = false;
                                IsWindTemp = true;
                                IsNextTemp = false;
                            }
                            else
                            {
                                IsHumidityTemp = false;
                                IsWindTemp = false;
                                IsNextTemp = false;
                            }
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            if (IsHumidityTemp)
                                this.Humidity = reader.Value;
                            else if (IsNextTemp)
                                this.Temp = int.Parse(reader.Value);
                            else if (IsWindTemp)
                                this.Wind = reader.Value;
                            break;
                    }
    
                }
    
                reader.Close();
            }
        }
    }
