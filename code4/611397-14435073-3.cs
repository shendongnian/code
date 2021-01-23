    public class Program
    {
        private static void Main(string[] args)
        {
            UserSettings userSettings = new UserSettings();
            userSettings.User.Default = "Programmer";
            userSettings.Level.Default = 2;
            userSettings.Level.Value = 99;
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
            Console.Out.WriteLine("User: HasDefault={0}, Default={1}, HasValue={2}, Value={3}", 
                deserializedUserSettings.User.HasDefault ? "Yes" : "No", 
                deserializedUserSettings.User.Default,
                deserializedUserSettings.User.HasValue ? "Yes" : "No", 
                deserializedUserSettings.User.Value);
            Console.Out.WriteLine("Level: HasDefault={0}, Default={1}, HasValue={2}, Value={3}",
                deserializedUserSettings.Level.HasDefault ? "Yes" : "No",
                deserializedUserSettings.Level.Default,
                deserializedUserSettings.Level.HasValue ? "Yes" : "No",
                deserializedUserSettings.Level.Value);
            Console.Out.WriteLine("IsFullscreen: HasDefault={0}, Default={1}, HasValue={2}, Value={3}",
                deserializedUserSettings.IsFullscreen.HasDefault ? "Yes" : "No",
                deserializedUserSettings.IsFullscreen.Default,
                deserializedUserSettings.IsFullscreen.HasValue ? "Yes" : "No",
                deserializedUserSettings.IsFullscreen.Value);
            Console.ReadLine();
        }
    }
