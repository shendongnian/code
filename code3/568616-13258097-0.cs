    var isoFileStream = myIsolatedStorage.OpenFile(myXmlFile, FileMode.Open);
    isoFileStream.Position = 0;
    
    var xdoc = XDocument.Load(isoFileStream);
    var reminderNodes = from n in xdoc.Descendants("Reminders") select n;
    
    foreach (var n in reminderNodes)
    {
        ProcessReminder(n);
    }
    void ProcessReminder(XElement node)
    {
        // do something... for now I'll just output to console.
        Console.WriteLine("Name: {0}", n.Element("Name").Value); 
        Console.WriteLine("Title: {0}", n.Element("Title").Value);
        Console.WriteLine("BeginTime: {0}", n.Element("BeginTime").Value);
        Console.WriteLine();
    }
