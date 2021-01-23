       var paramRegistry = new Dictionary<string,object>{
          {"@DataDB", CompBranch.AppDB},
          {"@OrigCpnyID", CompBranch. CompanyId},
          {"@CashAcct", CompBranch. CashAccount},
          {"@CashSub", CompBranch. CashSubAccount},
          ...
      };
      
      foreach (string Query in Client.InsertStatements(CurrentCompany.Modules.ToArray()))
      {
        foreach (Branch CompBranch in CurrentCompany.Branches)
        {
            SqlCommand cmd = new SqlCommand(Query);
            
            foreach(var parName in paramRegistry.Keys){
                if (Query.Contains(parName)){
                     cmd.Parameters.AddWithValue(parName,paramRegistry[parName]);
                }
            }
            Queries.RunQuery2(cmd, DestinationConnection.ConnectionString);
        }
    }   
  
