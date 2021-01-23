    // Add these to your references
    using System.IO;
    using PushSharp;
    using PushSharp.Apple;
    using PushSharp.Core;
    
    //Create our push services broker
    var push = new PushBroker();
    
    //Registering the Apple Service and sending an iOS Notification
    var appleCert = File.ReadAllBytes(string.Format(@"applePushCert.p12"));
    push.RegisterAppleService(new ApplePushChannelSettings(appleCert, "password"));
    push.QueueNotification(new AppleNotification()
            .ForDeviceToken("your device token")
            .WithAlert("Hello World!")
            .WithBadge(7)
            .WithSound("sound.caf")
            .WithCustomItem("content-available", 1));
