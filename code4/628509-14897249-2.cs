    private List<CustomerData> GetCustomers(string filename)
    {
        if (!File.Exists(filename))
            return new List<CustomerData>();
    
        XmlSerializer xs = new XmlSerializer(typeof(List<CustomerData>));
        using (FileStream fs = new FileStream(filename, FileMode.Open))
            return (List<CustomerData>)xs.Deserialize(fs);
    }
    
    public void SaveCustomers(string filename, List<CustomerData> customers)
    {
        XmlSerializer xs = new XmlSerializer(typeof(List<CustomerData>));
        using (FileStream fs = new FileStream(filename, FileMode.Create))
            xs.Serialize(fs, customers);
    }
