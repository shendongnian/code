    static void Main(string[] args)
    {
        Profile p = new Profile();
        p.ProfileColor = System.Windows.Media.Color.FromArgb(1, 1, 1, 0);
        p.WeatherTypes = new List<WeatherType>
            {
                WeatherType.Cloudy,
                WeatherType.Windy
            };
        var serializer = new XmlSerializer(typeof(Profile));
        var sb = new StringBuilder();
        TextWriter writer = new StringWriter(sb);
        serializer.Serialize(writer, p);
        Console.WriteLine(sb.ToString());
    }
