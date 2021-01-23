    public string SerializeGetCustomer(GetCustomer data)
    {
        return "{\"InteractionId\":\"" + data.InteractionId.ToString() + 
            "\",\"CustomerInfo\":" + data.CustomerInfo + "}";
    }
