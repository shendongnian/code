    private MyMailer() // objects initializer
    {
        client = new SmtpClient(SMTPServer);
        message = new MailMessage {IsBodyHtml = true};
    }
    private MyMailer(string from) //from setter
        : this() // calls MyMailer()
    {
        SetFrom(from);
    }
    public MyMailer(string from, string to, string cc, string bcc, string subject, string content)
        : this(from) // calls MyMailer(from)
    {
        foreach (string chunk in to.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries))
        {
            AddTo(chunk);    
        }
        foreach (string chunk in cc.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
        {
            AddCC(chunk);
        }
        foreach (string chunk in bcc.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
        {
            AddBCC(chunk);
        }
        SetSubject(subject);
        SetMessage(content);
        Send();
    }
