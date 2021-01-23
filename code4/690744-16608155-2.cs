    Car car = new Car("BMW");
    BinaryFormatter bFormatter = new BinaryFormatter();
    MemoryStream ms = new MemoryStream();
    bFormatter.Serialize(ms, car);
    System.Data.Linq.Binary carBinary 
        = new System.Data.Linq.Binary(ms.ToArray());
    TestDB db = new TestDB(ConfigurationManager.ConnectionStrings["TestDBConnectionString"].ConnectionString);
    db.InsertObjectSerialize(carBinary);
    ISingleResult<GetObjectSerializeResult> result = db.GetObjectSerialize(1);
    System.Data.Linq.Binary carBinaryFromDB
        = result.Single().Object;
    ms = new MemoryStream(carBinaryFromDB.ToArray());
    Car carFromDB = (Car)bFormatter.Deserialize(ms);
