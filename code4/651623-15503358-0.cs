        MeterValueList m = new MeterValueList();
         m.AdditionalParameter = 100;
        MemoryStream memorystream = new MemoryStream(); 
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(memorystream, m);
        byte[] yourBytesToDb = memorystream.ToArray();
        //here you write yourBytesToDb to database
        //----------read from database---------------------
        //here you read from database binary data into yourBytesFromDb
        MemoryStream memorystreamd = new MemoryStream(yourBytesFromDb);
        BinaryFormatter bfd = new BinaryFormatter();
        MeterValueList  md = bfd.Deserialize(memorystreamd) as MeterValueList ;
        var i  =  md.AdditinalParameter; // must print 100
