    public class Match
    {
    	public string Name { get; set; }
    	public string Score { get; set; }
    }
    
    public class Scorecard
    {
    	public List<Match> Match { get; set; }
    }
    
    public static Scorecard DeSerialize(Stream strm)
    {
    	var ser = new XmlSerializer(typeof(Scorecard));
    	strm.Seek(0, SeekOrigin.Begin);
    	return (Scorecard)ser.Deserialize(strm);
    }
    
    public static string Serialize(Scorecard scores)
    {
    	var ser = new XmlSerializer(typeof(Scorecard));
    	using (var strm = new MemoryStream())
    	{
    		var writer = XmlWriter.Create(strm, new XmlWriterSettings() { Indent = true, Encoding = System.Text.Encoding.UTF8 });
    		ser.Serialize(writer, scores);
    		strm.Seek(0, SeekOrigin.Begin);
    		return System.Text.Encoding.UTF8.GetString(strm.ToArray());
    	}
    }
    
    public void SaveXmlValue()
    {
    	Scorecard scores;
    	if (isoStore.FileExists("scoreboard.xml"))
    	{
    		using (IsolatedStorageFileStream isoStream =
    			new IsolatedStorageFileStream("scoreboard.xml", System.IO.FileMode.Open, isoStore))
    		{
    			scores = DeSerialize(isoStream);
    		}
    	}
    	else
    	{
    		// Xml file doesn't exist, create new score card object
    		scores = new Scorecard();
    		scores.Match = new List<Match>();
    	}
    
    	scores.Match.Add(new Match() { Name = VarGlobal.Name, Score = VarGlobal.Score });
    
    	var xml = Serialize(scores);
    	using (IsolatedStorageFileStream isoStream =
    			new IsolatedStorageFileStream("scoreboard.xml", System.IO.FileMode.Create, isoStore))
    	{
    		var buffer = System.Text.Encoding.UTF8.GetBytes(xml);
    		isoStream.Write(buffer, 0, buffer.Length);
    	}
    			
    }
