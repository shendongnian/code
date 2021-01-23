    StringWriter sw = new StringWriter( );
        HtmlTextWriter w = new HtmlTextWriter( sw );
        invoice.RenderControl( w ); //invoice is the div id of the element i am sending to email
        string s = sw.GetStringBuilder( ).ToString( );
        MailMessage message = new MailMessage( );
        message.IsBodyHtml = true;
        message.To.Add( new MailAddress( Session["eMail"].ToString( ) ) );
        message.To.Add( new MailAddress( "email@email.ca" ) );
        message.Subject = "extra dimensional stack-overflow";
        message.From = new MailAddress( "email@email.ca" );
        string a,b;
        a="<html><body>";
        b="</body></html>";
        message.Body = a + s + b;
        SmtpClient emailClient = new SmtpClient( "localhost", 8025 );
        System.Net.NetworkCredential SMTPUserInfo = new      System.Net.NetworkCredential( "blargh", "blargh" );
        emailClient.UseDefaultCredentials = false;
        emailClient.Credentials = SMTPUserInfo;
