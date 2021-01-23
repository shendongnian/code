    //I dunno what does this has to do, but I'll leave it here
    ListBox.SelectedObjectCollection SelectedItems = lstSelectedFiles.SelectedItems;
    //We are going to use a List<T> instead of ArrayList
    //also we are going to use Tuple<DateTime, String> for the items
    var LapsList = new List<Tuple<DateTime, String>>();
    foreach (string Selected in SelectedItems)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(Path + @"\" + Selected);
        XmlNodeList Laps = xDoc.GetElementsByTagName("Lap");
        foreach (XmlElement Lap in Laps)
        {
            var dateTime = DateTime.Parse(Lap.Attributes[0].Value);
            var str = Lap.InnerXml.ToString();
            //Here we create the tuple and add it
            LapsList.Add(new Tuple<DateTime, String>(dateTime, str));
        }
    }
    //We are sorting with Linq
    LapsList = LapsList.OrderBy(lap => lap.Item1).ToList();
