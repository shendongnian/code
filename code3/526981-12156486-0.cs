    var msg = new System.Net.Mail.MailMessage();
    msg.From = new System.Net.Mail.MailAddress("aaa@bb.com");
    msg.To.Add("cccc@ddd.net");
    msg.Subject = "test test";
    var client = new System.Net.Mail.SmtpClient();
    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory;
    client.PickupDirectoryLocation = @"c:\temp";
    client.Send(msg);
