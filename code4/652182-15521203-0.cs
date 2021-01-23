    // Add required columns
    listView1.Columns.Add("DMC");
    listView1.Columns.Add("Tech Name");
    listView1.Columns.Add("Info Name");
    listView1.Columns.Add("Status");
    listView1.Columns.Add("Notes");
    XDocument doc = XDocument.Load(CSDBpath + projectName + "\\Data.xml");
    foreach (var dm in doc.Descendants("dataModule"))
    {
        ListViewItem item = new ListViewItem( new string[]
        {
            dm.Element("DMC").Value,
            dm.Element("techName").Value,
            dm.Element("infoName").Value,
            dm.Element("status").Value,
            dm.Element("notes").Value
        });
        listView1.Items.Add(item);
    }
