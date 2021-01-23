    public void ProvideData(Guid providerKey, object data, string dataType)
    {
        if (!data.GetType().IsSerializable)
        {
            throw new ArgumentException("The data passed is not serializable and therefore is not valid.", "data");
        }
        var formatter = new BinaryFormatter();
        using (var fileStream = new FileStream("data.dat", FileMode.Create))
        {
            formatter.Serialize(fileStream, data);
            fileStream.Close();
        }
    }
