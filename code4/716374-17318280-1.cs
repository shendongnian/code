    string[] files = Directory.GetFiles("Directory of your file");
    foreach (string s in files)
    {
        if (s.Contains(@"FileName without extension"))
        {
            attachment = new System.Net.Mail.Attachment(s);
            mailMessage.Attachments.Add(attachment);   // mailMessage is the name of message you want to attach the attachment
        }
    }
