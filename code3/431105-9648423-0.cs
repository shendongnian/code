    // write
    YourType[] array = ...;
    Serializer.Serialize(destination, array);
    // read
    List<YourType> batch = new List<YourType>(1000);
    foreach(var item in Serializer.DeserializeItems<YourType>(source)) {
        batch.Add(item);
        if(batch.Count == 1000) {
            ProcessBatch(batch);
            batch.Clear();
        }
    }
    if(batch.Count != 0) ProcessBatch(batch);
