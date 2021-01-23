    public class Program
    {
        private static void Main(string[] args)
        {
            UserSettings userSettings = new UserSettings();
            userSettings.User = new DefaultableValue()
                {
                    Default = "Programmer", 
                    Value = "Tyler"
                };
            userSettings.Level = new DefaultableValue()
                {
                    Default = "2", 
                    Value = "99"
                };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserSettings));
            
            string serializedUserSettings;
            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, userSettings);
                serializedUserSettings = stringWriter.GetStringBuilder().ToString();
            }
            UserSettings deserializedUserSettings;
            using (StringReader stringReader = new StringReader(serializedUserSettings))
            {
                deserializedUserSettings = (UserSettings)xmlSerializer.Deserialize(stringReader);
            }
            Console.Out.WriteLine("User: Default={0}, Actual={1}", 
                deserializedUserSettings.User.Default, 
                deserializedUserSettings.User.Value);
            Console.Out.WriteLine("Level: Default={0}, Actual={1}", 
                deserializedUserSettings.Level.Default, 
                deserializedUserSettings.Level.Value);
        }
    }
