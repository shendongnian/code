    public void AddSerialNumber(SerialNumber serialNumber)
    {
        serialNumber.User = this;
        SerialHistory.Add(new SerialHistory { 
                                                SerialNumber = serialNumber, 
                                                DateAdded = DateTime.Now 
                                            });
    }
