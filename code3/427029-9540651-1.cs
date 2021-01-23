    public class SettingsReader()
    {
        public SettingsReader(System.IO.StreamReader reader)
        {
            // read contents of stream...
        }
    }
    // In production code:
    new SettingsReader(new StreamReader(File.Open("settings.xml")));
    // In unit test:
    new SettingsReader(new StringReader("<settings>dummy settings</settings>"));
