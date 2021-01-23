    foreach (string m in textBox6.Text.Split(';'))
    {
       System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(m);
       message.Attachments.Add(attachment);
    }
