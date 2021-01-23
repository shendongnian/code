    public class CommandSerializer
    {
      public commands Deserialize(string path)
      {
        CommandCollection commands = null;
        XmlSerializer serializer = new XmlSerializer(typeof(CommandCollection ));
        StreamReader reader = new StreamReader(path);
        reader.ReadToEnd();
        commands = (CommandCollection)serializer.Deserialize(reader);
        reader.Close();
        return commands ;
      }
    }
