    private async void OnPushNotification(PushNotificationChannel sender, PushNotificationReceivedEventArgs e)
    {
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (e.NotificationType != PushNotificationType.Raw) return;
                e.Cancel = true;
    
                try
                {
                    // Use ServiceStack.Text.WinRT to get this
                    var jsonObj = JsonSerializer.DeserializeFromString<JsonObject>(e.RawNotification.Content);
    
                    // TODO: Do something with this value now that it works
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err.Message);
                }
            });
    }
