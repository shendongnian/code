        //Saving
        SerializableArray t = new SerializableArray();
        t.2DArray[0,0] = 18383;
        SerializableArray.Serialize(t);
        //Loading
        SerializableArray t = TEST.Deserilize();
        
