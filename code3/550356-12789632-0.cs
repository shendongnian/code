    // ...
    var VID = testContextInstance.DataRow["VID"].ToString();
    var expectedResult = testContextInstance.DataRow["ExpectedResult"].ToString();
    var isVisit = new Service.ISVisit()
    {
        CID = Cid,
        MNum = MNumber,
        VCode = VID
    };
    // ...
    Assert.AreEqual(expectedResult, first.Proc.ProcID);
    
