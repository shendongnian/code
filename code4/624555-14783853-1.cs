    public void HandleCollectionData(IEnumerable<string> incomingData)
    {
        MyCollection.Clear();
        foreach(var item in incomingData)
        {
            MyCollection.Add(item);
        }
    }
