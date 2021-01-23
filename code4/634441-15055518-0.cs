    request.RequestFormat = DataFormat.Json;
    request.AddHeader("Accept", "application/json");
    request.OnBeforeDeserialization = resp => { cnt = resp.Content; };
                
    GitModels.IssuePost toPostIssue = Git2Bit.GitModels.Bit2GitTranslator.translate(bitIssue);
    
    request.AddBody(toPostIssue);
