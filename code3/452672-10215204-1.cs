    [TestMethod]
    public void GetValueOrDefault_ValueType_Test()
    {
        const string FieldName = "Column";
        const int Expected = 5;
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(FieldName, typeof(int));
        DataRow row = dataTable.Rows.Add(Expected);
        int actual = DataAccess.GetValueOrDefault<int>(row, FieldName);
        Assert.AreEqual(Expected, actual);
    }
    [TestMethod]
    public void GetValueOrDefault_ValueType_DBNull_Test()
    {
        const string FieldName = "Column";
            
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(FieldName, typeof(int));
        DataRow row = dataTable.Rows.Add(DBNull.Value);
        int actual = DataAccess.GetValueOrDefault<int>(row, FieldName);
        Assert.AreEqual(default(int), actual);
    }
    [TestMethod]
    public void GetValueOrDefault_ReferenceType_Test()
    {
        const string FieldName = "Column";
        object expected = new object();
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(FieldName, typeof(object));
        DataRow row = dataTable.Rows.Add(expected);
        object actual = DataAccess.GetValueOrDefault<object>(row, FieldName);
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void GetValueOrDefault_ReferenceType_DBNull_Test()
    {
        const string FieldName = "Column";
            
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(FieldName, typeof(object));
        DataRow row = dataTable.Rows.Add(DBNull.Value);
        object actual = DataAccess.GetValueOrDefault<object>(row, FieldName);
        Assert.AreEqual(default(object), actual);
    }
