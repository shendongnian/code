    public statc Order[] Deserialize(string path)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Order[]));
        Order[] result;
        using (XmlReader reader = XmlReader.Create(path))
        {
            result = (Order[]) ser.Deserialize(reader);
        }
        return result;
    }
