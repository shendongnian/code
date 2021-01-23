    public class Program
    {
        public static void Main()
        {
            using (var writer = XmlWriter.Create(Console.OpenStandardOutput()))
            {
                var telAvivProfile = new Profile
                    {
                        City = "Tel Aviv",
                        MaxTemp = 40,
                        MinTemp = 5,
                        ProfileColor = Color.FromRgb(4, 4, 4),
                        WeatherTypes = new List<WeatherType>
                            {
                                WeatherType.Sunny,
                                WeatherType.Rainy
                            }
                    };
    
                var serializer = new XmlSerializer(telAvivProfile.GetType());
                serializer.Serialize(writer, telAvivProfile);
    
                Console.WriteLine(writer.ToString());
            }
            Console.ReadLine();
        }
    }
    
    public enum WeatherType
    {
        Rainy,
        Sunny,
        Cloudy,
        Windy
    }
    
    [Serializable]
    [XmlRoot("Profile")]
    public class Profile
    {
        public string ProfileName { get; set; }
        public System.Windows.Media.Color ProfileColor { get; set; }
        public string City { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public List<WeatherType> WeatherTypes { get; set; }
    }
