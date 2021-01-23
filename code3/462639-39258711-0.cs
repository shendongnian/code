    // Download the twilio-csharp library from twilio.com/docs/csharp/install
    using System;
    using Twilio;
    class Example
    {
     static void Main(string[] args)
     {
        // Find your Account Sid and Auth Token at twilio.com/user/account
        string AccountSid = "YOUR_ACCOUNT_SID";
        string AuthToken = "YOUR_AUTH_TOKEN";
        var twilio = new TwilioRestClient(AccountSid, AuthToken);
    
        var message = twilio.SendMessage(
            "+15017250604", "+15558675309",
            "Hey Kyle! Glad you asked this question.",
            new string[] { "http://farm2.static.flickr.com/1075/1404618563_3ed9a44a3a.jpg" }
        );
        Console.WriteLine(message.Sid);
     }
    }
