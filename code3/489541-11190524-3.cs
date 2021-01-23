    private IDataIO dataIo = new ...
    private void SubscribeToData()
    { 
        dataIo.DataObservable.Buffer(16).Subscribe(On16Bytes);
    }
    private void On16Bytes(IList<byte> bytes)
    {
        // do stuff
    }
