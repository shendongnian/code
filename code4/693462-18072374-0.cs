    protected void btnSendMail_Click1(object sender, EventArgs e)
        {
            SmtpClient c = new SmtpClient("smtp.gmail.com", 587);
            MailAddress add = new MailAddress(txtReceiverEmailAddr.Text);
            MailMessage msg = new MailMessage();
            msg.To.Add(add);
            msg.From = new MailAddress(txtYourEmailAddr.Text);
            msg.IsBodyHtml = true;
            msg.Subject = txtSubject.Text;
            msg.Body = txtBody.Text;
            c.Credentials = new System.Net.NetworkCredential(txtYourEmailAddr.Text, txtYourPassword.Text);
            c.EnableSsl = true;
            c.Send(msg);
        }
