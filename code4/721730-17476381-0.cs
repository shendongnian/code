    public static MovieSummary Deserialize()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MovieSummary));
        TextReader textReader;
        
        textReader = new StreamReader(pathtoyourxmlfile);
        
        MovieSummary summary = (MovieSummary)serializer.Deserialize(textReader); 
        textReader.Close();
        return summary;
    }
