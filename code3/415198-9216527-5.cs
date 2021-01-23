    public void SerializeToXml(ArmyListing armyListing)
    {
        try
        {
            var serializer = new XmlSerializer(typeof (ArmyListing));
            using (var textWriter = new StreamWriter(@"C:\Test\40k.xml"))
            {
                serializer.Serialize(textWriter, armyListing);
            }
        }
        catch (Exception ex)
        {
        }
    }
