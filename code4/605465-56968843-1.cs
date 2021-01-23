    using System;
    using System.Web;
    using Newtonsoft.Json.Linq;
    using PushSharp.Apple;
    using System.Collections.Generic;
    
    namespace p12ios
    {
        public partial class iosp12 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                SendPushNotification(txtDeviceToken.Text, txtMessage.Text);
            }
    
            private void SendPushNotification(string deviceToken, string message)
            {
                try
                {
    
                    //Get Certificate
                    var appleCert =   System.IO.File.ReadAllBytes(Server.MapPath("~/IOS/"p12 certificate""));
    
                    // Configuration (NOTE: .pfx can also be used here)
                    var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, appleCert, "p12 Password");
    
                    // Create a new broker
                    var apnsBroker = new ApnsServiceBroker(config);
    
                    // Wire up events
                    apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
                    {
    
                        aggregateEx.Handle(ex =>
                        {
    
                            // See what kind of exception it was to further diagnose
                            if (ex is ApnsNotificationException)
                            {
                                var notificationException = (ApnsNotificationException)ex;
    
                                // Deal with the failed notification
                                var apnsNotification = notificationException.Notification;
                                var statusCode = notificationException.ErrorStatusCode;
                                string desc = $"Apple Notification Failed: ID={apnsNotification.Identifier}, Code={statusCode}";
                                Console.WriteLine(desc);
                                Label1.Text = desc;
                            }
                            else
                            {
                                string desc = $"Apple Notification Failed for some unknown reason : {ex.InnerException}";
                                // Inner exception might hold more useful information like an ApnsConnectionException			
                                Console.WriteLine(desc);
                                Label1.Text = desc;
                            }
    
                            // Mark it as handled
                            return true;
                        });
                    };
    
                    apnsBroker.OnNotificationSucceeded += (notification) =>
                    {
                        Label1.Text = "Apple Notification Sent successfully!";
                    };
                 
    
    
    
                    var fbs = new FeedbackService(config);
                    fbs.FeedbackReceived += (string devicToken, DateTime timestamp) =>
                    {
                        // Remove the deviceToken from your database
                        // timestamp is the time the token was reported as expired
                    };
    
                    // Start Proccess 
                    apnsBroker.Start();
    
                    var payload = new Dictionary<string, object>();
                    var aps = new Dictionary<string, object>();
                    aps.Add("alert", "This is a sample notification!");
                    aps.Add("badge", 1);
                    aps.Add("sound", "chime.aiff");
                    payload.Add("aps", aps);
    
                    payload.Add("confId", "20");
                    payload.Add("pageFormat", "Webs");
                    payload.Add("pageTitle", "Evalu");
                    payload.Add("webviewURL", "https:/UploadedImages/MobileApp/icons/Datalist-Defg");
                    payload.Add("notificationBlastID", "");
                    payload.Add("pushtype", "");
    
                    payload.Add("content-available", );
    
    
                    var jsonx = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
    
                    if (deviceToken != "")
                    {
                        apnsBroker.QueueNotification(new ApnsNotification
                        {
                            DeviceToken = deviceToken,
                            Payload = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(payload))
                        });
                    }
    
                    apnsBroker.Stop();
    
                }
                catch (Exception)
                {
    
                    throw;
                }
            }
        }
        
    }
