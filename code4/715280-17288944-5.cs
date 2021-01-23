    //I dunno what does this has to do, but I'll leave it here
    ListBox.SelectedObjectCollection SelectedItems = lstSelectedFiles.SelectedItems;
    //We are going to use a List<T> instead of ArrayList
    //also we are going to use the Laps class for the items
    var LapsList = new List<Lap>();
    foreach (string Selected in SelectedItems)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(Path + @"\" + Selected);
        XmlNodeList Laps = xDoc.GetElementsByTagName("Lap");
        foreach (XmlElement Lap in Laps)
        {
            var dateTime = DateTime.Parse(Lap.Attributes[0].Value);
            var str = Lap.InnerXml.ToString();
            //Here we create the Lap object and add it
            LapsList.Add(new Lap(dateTime, str));
        }
    }
    //We are sorting with Linq
    LapsList = LapsList.OrderBy(lap => lap.DateTimeValue).ToList();
