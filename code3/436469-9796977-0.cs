    private static readonly Logger log = new _EventLogger();
    
    private void btnSend_Click(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmdgetEmail = new SqlCommand("Select EMAIL, PATH from MEMBERREQUIREMENTS WHERE STATUS=0", conn);
        SqlDataReader getEmail = cmdgetEmail.ExecuteReader();
        while (getEmail.Read())
        {
            email = getEmail.GetString(0);
            attachment = getEmail.GetString(1);
            this.sendMail(email, attachment)
        }
        getEmail.Close();
        conn.Close();
    }
    
    private void sendMail(string sendTo, string sendAttachments)
    {
        MailMessage mail = new MailMessage();
        mail.To.Add(sendTo);
        mail.From = new MailAddress(from, "Company Name'", Encoding.UTF8);
        mail.Subject = subject;
        mail.Body = msgBodyHead + msgBodyHead2 + msgDate + msgGreet + msgBody + msgAdobe + msgAssistance + msgCompliment + msgfooter;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        mail.Attachments.Add(new Attachment(sendAttachments));
    
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential(from, "password");
        client.Host = "192.167.89.0";
        client.EnableSsl = false;
        try
        {
    
            progress();
            client.Send(mail);
    
        }
    
        catch (Exception ex)
        {
            ProgressBar1.Visible = false;
            timer1.Enabled = false;
            Exception excpt = ex;
            string errorMessage = string.Empty;
    
            while (excpt != null)
            {
    
                errorMessage += excpt.ToString(); excpt = excpt.InnerException;
                log.Error("Email - LMS Application Error", ex);
                lblError.Text = "There was an error occured while processing your request.\n Please see Event Viewer for more details.";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
