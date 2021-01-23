    File.WriteAllLines(path, contents);
    using(System.Net.Mail.MailMessage mailMessage 
                                    = new System.Net.Mail.MailMessage())
    {
    // send mail containing the file here
    }
    File.Delete(path);
