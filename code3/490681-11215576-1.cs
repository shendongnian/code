    var result;
    try
    {
        memberServiceClient = new MemberServiceClient();
        result = memberServiceClient.GetUserTypeFromProfileID(profileID);
    }
    catch (FaultException e)
    {
        //handle exception
        memberServiceClient .Abort();
    }
    catch (CommunicationException e)
    {
        //handle exception
        memberServiceClient .Abort();
    }
    catch (TimeoutException e)
    {
        //handle exception
        client.Abort();
    }
    memberServiceClient.Dispose();
