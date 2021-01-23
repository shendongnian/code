    public async bool Register(UserInfo info)
    {
        try
        {
            using (mydatabase db = new mydatabase())
            {
                userinfotable uinfo = new userinfotable();
                uinfo.Name = info.Name;
                uinfo.Age = info.Age;
                uinfo.Address = info.Address;
                db.userinfotables.AddObject(uinfo);
                db.SaveChanges();
                //Wait for task to finish asynchronously
                await Utility.SendEmail(info);
                return true;
            }
        }
        catch { return false; }
    }
    private async Task SendEmail(MailMessage mail)
    {
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.something.com";
        client.Port = 123;
        client.Credentials = new System.Net.NetworkCredential("username@domainserver.com", "password");
        client.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
        //The smtp SendTaskAsync is an extension method when using Async CTP
        await client.SendTaskAsync("from", "recipients", "subject", "body");
    }
