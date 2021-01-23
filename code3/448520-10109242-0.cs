    [SetUp]
    public void TestSetup()
    {
       _dataField =  new DataField(dependency1, dependency2, dependency3);
    }
    
    [Test]
    public void DataField_Gets_Properly_Created()
    {
        Assert.NotNull(dataField.Id);
        // other assertions ...
    }
    
    [Test]
    public void Most_Test_Using_dataField()
    {
        ...
    }
