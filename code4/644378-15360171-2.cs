    private async void OnPushNotification(PushNotificationChannel sender, PushNotificationReceivedEventArgs e)
    {
        String notificationContent = String.Empty;
    
        switch (e.NotificationType)
        {
            case PushNotificationType.Badge:
            case PushNotificationType.Tile:
            case PushNotificationType.Toast:
                notificationContent = e.TileNotification.Content.GetXml();
                break;
    
    
            case PushNotificationType.Raw:
                notificationContent = e.RawNotification.Content;
    
                e.Cancel = true;
    
                try
                {
                    // Use ServiceStack.Text.WinRT to get this
                    var jsonObj = JsonSerializer.DeserializeFromString<JsonObject>(notificationContent);
    
                    // TODO: Do something with this value now that it works
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err.Message);
                }
    
                break;
        }
