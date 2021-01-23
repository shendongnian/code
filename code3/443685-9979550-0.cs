    public class MyProgram
    {
    	public string FileName { get; set; }
    	public string FilePath { get; set; }
    }
    
    // load data file
    using ( XmlTextReader xmlReader = new XmlTextReader("myfilename.xml") )
    {
    	XDocument xdoc = XDocument.Load(xmlReader);
    
    	var programs= from programItem in xdoc.Root.Elements()
    				select new MyProgram {
    					FileName = programItem.Element("File-name").Value,
    					FilePath = programItem.Element("File-path").Value
    				};
    
    	List<MyProgram> programs = items.ToList();
    }
