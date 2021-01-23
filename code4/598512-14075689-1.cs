    MyDataList.AddRange(
        Database.ExecuteReader<List<MyDataModel>>( //Tell ExecuteReader what type of object to return
        connection, //Pass in the connection
        commandString, //Pass in the command
        delegate(IDataReader reader) //This code is called from inside the ExecuteReader method.
        {
            List<MyDataModel> List = new List<MyDataModel>();
            while (reader.Read())
            {
                //Read each record, transform it into MyDataModel, then add it to the List.
            }
            return List;
        }
    }));
