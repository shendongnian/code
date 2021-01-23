     AWSCredentials objAWSCredentials = new BasicAWSCredentials(AWSAccessKey, AWSSecretKey);
     Destination destination = new Destination().WithToAddresses(new List<string>() { TO });
     // Create the subject and body of the message.
     Content subject = new Content().WithData(SUBJECT);
     Content textBody = new Content().WithData(BODY);
     Body body = new Body().WithHtml(textBody);
     //Body body = new Body().WithText(textBody);
     // Create a message with the specified subject and body.
     Message message = new Message().WithSubject(subject).WithBody(body);
     // Assemble the email.
     SendEmailRequest request = new SendEmailRequest().WithSource(FROM).WithDestination(destination).WithMessage(message).WithReplyToAddresses(REPLYTO);
     // Instantiate an Amazon SES client, which will make the service call. Since we are instantiating an 
     // AmazonSimpleEmailServiceClient object with no parameters, the constructor looks in App.config for 
     // your AWS credentials by default. When you created your new AWS project in Visual Studio, the AWS
     // credentials you entered were added to App.config.
     AmazonSimpleEmailServiceClient client = new AmazonSimpleEmailServiceClient(objAWSCredentials);
     // Send the email.
     Console.WriteLine("Attempting to send an email through Amazon SES by using the AWS SDK for .NET...");
     client.SendEmail(request);
