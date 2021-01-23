    foreach (DTO DTO in LotsOfWork)
    {
    
    	object result = null; //Initialize as null
    
    	matlab.Execute("clear;");
    	matlab.PutWorkspaceData("a", "base", DTO.Parameter1);
    	matlab.PutWorkspaceData("b", "base", DTO.Parameter2);
    	matlab.Execute("result = a + b;");
    	matlab.GetWorkspaceData("result", "base", out result);
    }
