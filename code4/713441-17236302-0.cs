        XElement xe = client.QueryXml("SELECT Uri FROM Orion.Pollers WHERE NetObjectID = 15", null);
        IList<XElement> indexedElements = xe.Elements().ToList();
        foreach (var item in ((XElement)xe.Elements().ToList()[1]).Elements().ToList())
        {
            try
            {
                //Do something with 
                //item.Value
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
