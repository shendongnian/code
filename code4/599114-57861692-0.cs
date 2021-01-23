    TwilioClient.Init(accountSid, authToken);
    var message = MessageResource.Create(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber(fromNumber),
                to: new Twilio.Types.PhoneNumber(toNumber)
            );
    Console.WriteLine(message.Sid);
    //Get the status from twilio
    TwilioClient.Init(accountSid, authToken);
    var verificationCheck = MessageResource.Fetch(message.Sid);
    Console.WriteLine(verificationCheck.Status);
