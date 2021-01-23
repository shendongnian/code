    var result;
    try
    {
        memberServiceClient = new MemberServiceClient();
        result = memberServiceClient.GetUserTypeFromProfileID(profileID);
        memberServiceClient.Close();
    }
    catch (FaultException e)
    {
        //handle exception
        memberServiceClient.Abort();
    }
    catch (CommunicationException e)
    {
        //handle exception
        memberServiceClient.Abort();
    }
    catch (TimeoutException e)
    {
        //handle exception
        memberServiceClient.Abort();
    }
