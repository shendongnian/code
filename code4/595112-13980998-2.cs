    private static object mylock = new object();
    public static void ReceiveResponse(IAsyncResult Result)
    {
        ...
        finally
        {
            oSMS.Complete = DateTime.Now;
    
            Recipient CompleteMessage = new Recipient(oSMS.MessageID, oSMS.Recipient, oSMS.ErrorCode, oSMS.Complete, oSMS.ResponseCode);
            lock (mylock)
            {
				Recipients.Add(CompleteMessage);
			}
        }
	}
