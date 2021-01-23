    private async void OnPushNotification(PushNotificationChannel sender, PushNotificationReceivedEventArgs e)
    {
        if (e.NotificationType == PushNotificationType.Raw)
        {
            e.Cancel = true;
    
            String notificationContent = String.Empty;
    
            notificationContent = e.RawNotification.Content;
        }
    }
