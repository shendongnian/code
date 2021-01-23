    public statc void SerializeOrders(Order[] orders, string path)
    {
       XmlSerializer parse = new XmlSerializer(typeof(Order[]));
       using (var writer = new StreamWriter(path))
       {
          parse.Serialize(writer, orders);
          writer.Close();
       }
    }
