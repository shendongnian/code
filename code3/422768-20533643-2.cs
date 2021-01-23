    public void SaveData(MyObjectThatNeedToBeConstructed myObject){
        // ... 
        // get your writer (Stream) from memory or wherever it's located
        var serializer = new DataContractSerializer(typeof(MyClassDataModel));
        var dataModel = new MyClassDataModel{ DataMemberExample = myObject.DataMember};
        serializer.WriteObject(writer, dataModel);
    }
