            checkForPushRequest();
        }
        static void checkForPushRequest()
        {
            string YourConnString = "YourConnectionStringToTheDBGoesHere";
                Stored_Procedure SP = new Stored_Procedure {
                Name = "get_APNSToSend",
		        Parameters = new List<SqlParameter>()
	        };
	      
	        try {
		        System.Data.DataTable dt = DatabaseOperations.Execute_Database_Command(YourConnString, SP, true);
       
		        if ((dt != null) && !(dt.Rows.Count < 1)) {
			        foreach (System.Data.DataRow dRow in dt.Rows) {
                        string deviceToken = Convert.ToString(dRow[1]);
                        string alertMessage = Convert.ToString(dRow[2]);
                        int badgeNumber =  Convert.ToInt16(dRow[3]);
                        string soundFile = Convert.ToString(dRow[4]);
                        string apnsCertFileToUse = Convert.ToString(dRow[5]);
                        sendPush(deviceToken, alertMessage, soundFile, badgeNumber, apnsCertFileToUse);
			        }
		        }
	        } catch (Exception ex) {
		        // Handle your exception
            }
        }
        static void sendPush(string DeviceToken, string AlertMessage, string SoundFile, int BadgeNumber, string apnsCertFileToUse)
        {
            //Create our service	
            PushService push = new PushService();
            
            //Wire up the events
            push.Events.OnDeviceSubscriptionExpired += new PushSharp.Common.ChannelEvents.DeviceSubscriptionExpired(Events_OnDeviceSubscriptionExpired);
            //push.Events.OnDeviceSubscriptionIdChanged += new PushSharp.Common.ChannelEvents.DeviceSubscriptionIdChanged(Events_OnDeviceSubscriptionIdChanged);
            push.Events.OnChannelException += new PushSharp.Common.ChannelEvents.ChannelExceptionDelegate(Events_OnChannelException);
            push.Events.OnNotificationSendFailure += new PushSharp.Common.ChannelEvents.NotificationSendFailureDelegate(Events_OnNotificationSendFailure);
            push.Events.OnNotificationSent += new PushSharp.Common.ChannelEvents.NotificationSentDelegate(Events_OnNotificationSent);
            //Configure and start Apple APNS
            // IMPORTANT: Make sure you use the right Push certificate.  Apple allows you to generate one for connecting to Sandbox,
            //   and one for connecting to Production.  You must use the right one, to match the provisioning profile you build your
            //   app with!  
            //  This comes from the ApplicationInfo table.  Each app that supports APNS has it's own certfile name in the column
            string certFileToUse = "C:\\APNS_Certs\\" + apnsCertFileToUse;
  
            var appleCert = File.ReadAllBytes(certFileToUse);
            //IMPORTANT: If you are using a Development provisioning Profile, you must use the Sandbox push notification server 
            //  (so you would leave the first arg in the ctor of ApplePushChannelSettings as 'false')
            //  If you are using an AdHoc or AppStore provisioning profile, you must use the Production push notification server
            //  (so you would change the first arg in the ctor of ApplePushChannelSettings to 'true')
            push.StartApplePushService(new ApplePushChannelSettings(false, appleCert, "P12PasswordHere"));
            //Fluent construction of an iOS notification
            //IMPORTANT: For iOS you MUST MUST MUST use your own DeviceToken here that gets generated within your iOS app itself when the Application Delegate
            //  for registered for remote notifications is called, and the device token is passed back to you
            push.QueueNotification(NotificationFactory.Apple()
                .ForDeviceToken(DeviceToken)
                .WithAlert(AlertMessage)
                .WithSound(SoundFile)
                .WithBadge(BadgeNumber));
            //Console.WriteLine("Waiting for Queue to Finish...");
            //Stop and wait for the queues to drains
            push.StopAllServices(true);
           // Console.WriteLine("Queue Finished, press return to exit...");			
        }
