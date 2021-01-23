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
                break;
        }
    
        e.Cancel = true;
    
    
        try
        {
            JObject jObject = JObject.Parse(notificationContent);
    
            JToken jToken;
    
            jObject.TryGetValue("refresh", out jToken);
    
            bool refreshValue = jToken != null && Convert.ToBoolean(jToken.ToString());
    
            if (refreshValue)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, RefreshTodoItems);
            }
        }
        catch (Exception err)
        {
            Debug.WriteLine(err.Message);
        }
    }
