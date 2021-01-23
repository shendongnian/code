    string filePath = ".\\Demo.xml";
    private void Form1_Load(object sender, EventArgs e)
    {
        ReadSettings();
    }
    void ReadSettings()
    {
        XmlSerializer s = new XmlSerializer(typeof(Settings));
        Settings newSettings = null;
        using (StreamReader sr = new StreamReader(filePath))
        {
            try
            {
                newSettings = (Settings)s.Deserialize(sr);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.ToString());
            }
        }
        if (newSettings != null)
            this.Text = newSettings.WatchPath;
    }
    
    public class Settings
    {
        public string WatchPath { get; set; }
    }
