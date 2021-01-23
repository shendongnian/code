    private void SmtpClientSendCompleted(object sender, AsyncCompletedEventArgs e){
        var smtpClient = (SmtpClient) sender;
        var userAsyncState = (SendAsyncState) e.UserState;
        smtpClient.SendCompleted -= SmtpClientSendCompleted;
        if(e.Error != null) {
           tracer.ErrorEx(
              e.Error, 
              string.Format("Message sending for \"{0}\" failed.",userAsyncState.EmailMessageInfo.RecipientName)
           );
        }
        // Cleaning up resources
        .....
    }
