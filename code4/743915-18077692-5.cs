      // looks better than
      // A.GetPerformed().GetValidated().GetSentTo(@"Me@MyServer.com"); 
      A.Perform().Validate().SendTo(@"Me@MyServer.com"); 
    
      // The same with transpose:
      // easier to read than
      // A.GetTransposed().GetAppied(x => x * x).GetToString();
      A.Transpose().Apply(x => x * x).ToString();
      
