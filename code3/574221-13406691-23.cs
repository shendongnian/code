    private RootObject GetData()
    {
        string jsonMessage;
        
        #region Initialise String
        jsonMessage = @"";
        #endregion
        var data = JsonConvert.DeserializeObject<RootObject>(jsonMessage);
        Assert.That(data, Is.Not.Null);
        Assert.That(data, Is.InstanceOf<RootObject>());
        Assert.That(data.MRData, Is.Not.Null);
        Assert.That(data.MRData, Is.InstanceOf<MRData>());
        Assert.That(data.MRData.StandingsTable, Is.Not.Null);
        Assert.That(data.MRData.StandingsTable, Is.InstanceOf<StandingsTable>());
        return data;
    }
