    oPushService.QueueNotification(NotificationFactory.Apple()
        .ForDeviceToken("YourDeviceTokenASDASD!@#SDF")
        .WithCustomItem("MyCustomItem","Item 3")
        .WithAlert("Alert pop message")
        .WithSound("default")
        .WithBadge(7))); On the Client Side:  void processNotification(NSDictionary options, bool fromFinishedLaunching) { 			 (options != null && options.ContainsKey(new NSString("aps"))) {    
        NSDictionary alertMsg = options; 
        NSObject codeCustomValue = alertMsg[NSObject.FromObject("MyCustomItem")];
        // .... and continue your code....  }
