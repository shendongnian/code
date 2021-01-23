    private void previousList_Click(object sender, EventArgs e)
    {
        pid = 14;
    
        XDocument xDoc = XDocument.Load(@"C:\Users\HDAdmin\Documents\Fatty\SliceEngine\SliceEngine\bin\Debug\simpan.xml");
    
        var name = xDoc.Root
                       .Descendants("myself")
                       .FirstOrDefault(e => e.Element("pid")
                       .Value
                       .Equals(pid.ToString(CultureInfo.InvariantCulture)))
                       .Element("name").Value;
    
        textETA.Text = name;
    }
