    private void Events_OnNotificationFailed(object sender, INotification notification, Exception error)
    {
        var gcmNotification = notification as GcmNotification;
        bool userHasUninstalled = error.Message.Contains("Device Subscription has Expired");
        bool isAndroidNotification = gcmNotification != null;
        if (isAndroidNotification && userHasUninstalled)
        {
            foreach (var registrationId in gcmNotification.RegistrationIds)
            {
                DeleteDeviceByIdentifier(registrationId);
            }
        }
    }
        
        
