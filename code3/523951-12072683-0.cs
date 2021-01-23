    [Test, TestCaseSource("insertScenarios")]
    public void TestInsert()
    {
        WorkflowRuntime runtime = //some value;
        string description = //some value; 
        bool DocOneUploaded = //some value;
        bool DocTwoUploaded = //some value;
        string Reason = //some value;
        var message = Business.InsertBoatHandoverOutsideCrew(runtime, description, DocOneUploaded, DocTwoUploaded, Reason);
        Assert.AreNotEqual(0, message.Id);
    }
