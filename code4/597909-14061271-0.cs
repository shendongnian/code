    var groupedOrders = listOfOrders.GroupBy(o => o.Placement_ID);
    foreach (var group in groupedOrders)
    {
        //Create document, but don't add any fills
        XDocument doc = new XDocument(...)
        int n = 1;
        foreach (var fill in group)
        {
            //Same structure as before, just a separate element
            XElement newFillElement = new XElement("fill" + n, ...);
            //Add as last element to existing doc
            doc.Add(newFillElement);
            n++
        }
    }
