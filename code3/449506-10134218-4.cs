    public ObservableCollection<string> Servers {get; set;}
    string fileName = "c:\\users\\xxxxx\\documents\\visual studio 2010\\Projects\\WpfApplication2\\WpfApplication2\\XML.xml";
    var doc = XDocument.Load(fileName);
    var findString = "server";
    
    var results = doc.Element("Servernames").Descendants("Servername").Where (d => d.Value.Contains(findString)).Select (d => d.Value);
    Servers = new ObservableCollection<string>(results);
    
