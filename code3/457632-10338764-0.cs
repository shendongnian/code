    protected void os_submit_Click ( object sender, EventArgs e )
    {
        MailMessage mm = new MailMessage( "OnlineSignup@help.com", "help@help.com" );
        mm.Subject = "Online Signup Checklist";
        mm.Body = Request.Form["editor2"]; // Trying to grab the value of the textarea
        mm.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "127.0.0.1";
        smtp.Port = 25;
        smtp.Send( mm );
    }
