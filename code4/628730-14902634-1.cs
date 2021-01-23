    Team myTeamData = new Team();
    // add some players on it.
    XmlSerializer deserializer = new XmlSerializer(typeof(Team));
    using (TextReader textReader = new StreamReader(@"C:\temp\temp.txt"))
    {
        myTeamData = (Team)deserializer.Deserialize(textReader);
        textReader.Close();
    }
