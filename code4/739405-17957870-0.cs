    private bool globalBool;
    public static bool SenddNotification()
    {
    var push = new PushBroker();
    
            //Wire up the events for all the services that the broker registers
            push.OnNotificationSent += NotificationSent;
            push.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
            return globalBool;  
    }
    
    
    static bool DeviceSubscriptionChanged(object sender, string oldSubscriptionId, string newSubscriptionId, INotification notification)
        {
            //Currently this event will only ever happen for Android GCM
            Console.WriteLine("Device Registration Changed:  Old-> " + oldSubscriptionId + "  New-> " + newSubscriptionId + " -> " + notification);
            globalBool = false;
        }
    
        static bool NotificationSent(object sender, INotification notification)
        {
            Console.WriteLine("Sent: " + sender + " -> " + notification);
            globalBool = true;
        }
