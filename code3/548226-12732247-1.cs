    public void TestInsert()
    {
        _mock.Setup(r => r.Find(record).Returns(null))
        class = new class(_mock.Object);
        class.methodToTest(fileRecord);
        _mock.Verify( r => r.Insert(record));
    }
    public void TestUpdate()
    {
        var dbRecordThatPassesLogicCheck = new dbRecord(// initialize for test)
        _mock.Setup(db => db.Find(record).Returns(dbRecordThatPassesLogicCheck))
        
        class = new class(_mock.Object);
        class.methodToTest(fileRecord);
        _mock.Verify( r => r.Update(dbRecordThatPassesLogicCheck));
    }
    public void TestUpdate3()
    {
        var dbRecordThatPassesLogicCheck2 = new dbRecord(// initialize for test)
        _mock.Setup(db => db.Find(record).Returns(dbRecordThatPassesLogicCheck2))
        
        class = new class(_mock.Object);
        class.methodToTest(fileRecord);
        _mock.Verify( db => db.Update3(dbRecordThatPassesLogicCheck2));
    }
