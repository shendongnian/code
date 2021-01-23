    public static Task SendAsync(this SmtpClient client, MailMessage message)
    {
        TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
        Guid sendGuid = Guid.NewGuid();
    
        SendCompletedEventHandler handler = null;
        handler = (o, ea) =>
        {
            if (ea.UserState is Guid && ((Guid)ea.UserState) == sendGuid)
            {
                client.SendCompleted -= handler;
                if (ea.Cancelled)
                {
                    tcs.SetCanceled();
                }
                else if (ea.Error != null)
                {
                    tcs.SetException(ea.Error);
                }
                else
                {
                    tcs.SetResult(null);
                }
            }
        };
    
        client.SendCompleted += handler;
        client.SendAsync(message, sendGuid);
        return tcs.Task;
    }
