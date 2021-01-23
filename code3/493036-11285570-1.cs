     public Result CreateTestplan(Testplan testplan)
     {
        Result res = new Result();
        try
        {
        using (var con = new SqlConnection(_connectionString))
        using (var trans = new TransactionScope())
        {
           con.Open();
    
           _testplanDataProvider.AddTestplan(testplan);
           _testplanDataProvider.CreateTeststepsForTestplan(testplan.Id, testplan.TemplateId);
           trans.Complete();
           result.Success = true;
       }
       }
       catch (Exception e)
       {
           result.Error = e.Message;
       }
       return result;
      }
    
    class Result
    {
       public bool Success {get;set;}
       public string Error {get;set;}
    }
