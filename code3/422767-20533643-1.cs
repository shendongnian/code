    public MyObjectThatNeedToBeConstructed LoadData(){
        // ... 
        // get your reader (Stream) from the file system or wherever it's located
        var deserializer = new DataContractSerializer(typeof(MyClassDataModel));
        var storedModel = (MyClassDataModel)deserializer.ReadObject(reader);
        return new MyObjectThatNeedToBeConstructed(storedModel);
    }
