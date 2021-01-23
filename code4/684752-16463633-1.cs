    MailMessage msg = (MailMessage)e.UserState;
    if (e.Cancelled)
    {
        // force synchronous send
        smptClient.Send(msg);
    }
    msg.Dispose(); // dispose of the message as we no longer need it
    if (e.Error != null)
    {
        Log(e.Error.ToString() + " in SendCompletedHandlerEvent", EventLogEntryType.Error);
    }
