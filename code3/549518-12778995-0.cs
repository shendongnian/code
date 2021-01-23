    SendEmailRequest req = new SendEmailRequest()                        
                        .WithDestination(new Destination() { ToAddresses = { SimulatorMails } })
                        .WithSource(VerifiedMail)
                        .WithReturnPath(VerifiedMail)
                        .WithMessage(
                            new Amazon.SimpleEmail.Model.Message(new Content("Title"),
                            new Body().WithHtml(new Content("Body"));
