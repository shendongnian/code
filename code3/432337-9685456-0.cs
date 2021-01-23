    public void AddNotification(UserNotification notification)
    {
        AddNotification(notification, false);
    }
        
    public void AddNotification(UserNotification notification, bool useOriginalSender)
    {
        _notifications.Add(notification);
        notification.Notification += (originalSender, e) =>
                    {
                        var temp = NotificationRaised;
                        if (temp != null)
                        {
                            var sender = useOriginalSender ? originalSender : this;
                            temp(sender, NotifyEventArgs.Empty);
                        }
                    };
    }
