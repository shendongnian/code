    public Dictionary<string, DateTime> Dates
    {
        get
        {
            return new Dictionary<string, DateTime>()
            {
                new KeyValuePair<string, DateTime>("ReceivedDate", ReceivedDate),
                new KeyValuePair<string, DateTime>("DeliveryDate", DeliveryDate),
                ...
            }
        }
    }
    ...
    foreach (var d in shipment.Dates)
    {
        Console.WriteLine(d.Key, d.Value);
    }
