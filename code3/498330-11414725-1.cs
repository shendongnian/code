    private DataBaseObject MapObjectToList(IDataReader objDataReader)
    {
        DataBaseObject obj = new DataBaseObject();
        obj.Prop1Name = base.GetDataValue<string>(objDataReader, "Column1Name");
        obj.Prop2Name = base.GetDataValue<string>(objDataReader, "Column2Name");
        return obj;
    }
