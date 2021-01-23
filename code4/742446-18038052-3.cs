    protected void Btn_SendMail_Click(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage();
    
        ContentType mimeType = new System.Net.Mime.ContentType("text/html");
        // Decode the html in the txtBody TextBox...	
        string body = HttpUtility.HtmlDecode(txtBody.Text);
        AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
        msg.AlternateViews.Add(alternate);
    
        msg.From = new MailAddress("danieleluciani92@gmail.com");
        msg.To.Add("danieleluciani92@gmail.com");
        msg.Subject = txtSubject.Text;
        msg.IsBodyHtml = true;
        msg.Body = body;
        SmtpClient sc = new SmtpClient("smtp.gmail.com");
        sc.Port = 25;
        sc.Credentials = new NetworkCredential("danieleluciani92@gmail.com", "Dead2006!");
        sc.EnableSsl = true;
        sc.Send(msg);
        Response.Write("<script>alert('ennamo');</script>");
    }
