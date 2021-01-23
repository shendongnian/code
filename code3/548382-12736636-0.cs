    void Main()
    {
    	// Settings in a Text File
    	string path1 = @"C:\\Dev\\settings.txt";
    	string setting1;
    	string setting2;
    	setting1 = "foo";
    	setting2 = "bar";
    	SaveSettingsToTextFile(path1, setting1, setting2);
    	setting1 = "";
    	setting2 = "";
    	LoadSettingsFromTextFile(path1, out setting1, out setting2);
    	Console.WriteLine(setting1);
    	Console.WriteLine(setting2);
    	
    	// Settings in an Xml File
    	string path2 = @"C:\\Dev\\settings.xml";
    	MySettings mySettings = MySettings.Create(path2);
    	mySettings.setting1 = "bat";
    	mySettings.setting2 = "baz";
    	mySettings.Save();	
    	mySettings = null;
    	mySettings = MySettings.Create(path2);
    	Console.WriteLine(mySettings.setting1);
    	Console.WriteLine(mySettings.setting2);
    }
    
    void SaveSettingsToTextFile(string path, string setting1, string setting2)
    {
    	var sb = new StringBuilder();
    	sb.AppendLine(setting1);
    	sb.AppendLine(setting2);
    	File.WriteAllText(path, sb.ToString());
    }
    
    void LoadSettingsFromTextFile(string path, out string setting1, out string setting2)
    {
    	var lines = File.ReadLines(path).ToArray();
    	setting1 = lines[0];
    	setting2 = lines[1];
    }
    
    public class MySettings
    {
    	public string setting1 { get; set; }
    	public string setting2 { get; set; }
    	
    	static XmlSerializer serializer = new XmlSerializer(typeof(MySettings));
    		
    	public static MySettings Create(string savePath)
    	{
    		MySettings instance;
    		if(File.Exists(savePath))
    		{
    			var xDoc = XDocument.Load(savePath);
    			var reader = xDoc.CreateReader();
    			instance = (MySettings)serializer.Deserialize(reader);
    			reader.Close();
    		}
    		else
    		{
    			instance = new MySettings();
    		}
    		instance.SavePath = savePath;
    		return instance;
    	}
    	
    	public void Save()
    	{
    		var xDoc = new XDocument();
    		var writer = xDoc.CreateWriter();
    		serializer.Serialize(writer, this);
    		writer.Close();
    		File.WriteAllText(this.SavePath, xDoc.ToString());
    	}
    
    	[XmlIgnore]
    	public string SavePath { get; private set; }
    }
