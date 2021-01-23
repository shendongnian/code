    try
    {
        Guid emailGuid = p.Create(email);        
    	OrganizationRequest request = new OrganizationRequest() { RequestName = "SendEmail" };
    	request["EmailId"] = emailGuid; // now is the right variable
    	request["TrackingToken"] = "";
    	request["IssueSend"] = true;
    	OrganizationResponse rsp = p.Execute(request);
    }
    catch (Exception e)
    {
        Console.WriteLine("error " + e.Message);
        Console.ReadLine();
    }
