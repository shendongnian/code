    using(FbConnection c = new FbConnection(csb.ToString()))
    {
        FbBatchExecution fbe = new FbBatchExecution(c);
        //loop through your commands here
        {
    		fbe.SqlStatements.Add(cmd);
        }
        fbe.Execute();
    }
