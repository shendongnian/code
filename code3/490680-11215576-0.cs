    var result;
    try
    {
        memberServiceClient = new MemberServiceClient();
        result = memberServiceClient.GetUserTypeFromProfileID(profileID);
    }
    catch (CommunicationException e)
    {
        //handle exception
        memberServiceClient .Abort();
    }
    catch (TimeoutException e)
    {
        //handle exception
        memberServiceClient .Abort();
    }
    catch (FaultException e)
    {
        //handle exception
        client.Abort();
    }
    memberServiceClient.Dispose();
