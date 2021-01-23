    /// <summary>
    /// C:\Users\Johan\AppData\Local\Google\Chrome\User Data\Default
    /// </summary>
    [TestFixture]
    public class ChromeBookMarks
    {
        [Test]
        public void RoundTripBookmarksTest()
        {
            JsonSerializer jsonSerializer = JsonSerializer.Create(
                new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Error,
                    });
            RootObject rootObject;
            using (JsonTextReader jsonTextReader = new JsonTextReader(new StringReader(Properties.Resources.Bookmarks))) //I added my bookmars as an embedded txt file for convenience
            {
                rootObject = jsonSerializer.Deserialize<RootObject>(jsonTextReader);
            }
            //Here you have the contents of the bookmarks file in rootObject if you need to do manipulations
            StringBuilder stringBuilder = new StringBuilder();
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(new StringWriter(stringBuilder)))
            {
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonTextWriter.Indentation = 3;
                jsonSerializer.Serialize(jsonTextWriter, rootObject);
            }
            var json = stringBuilder.ToString();
            File.WriteAllText(@"C:\person.json", json);
        }
    }
