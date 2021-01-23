        protected void BtnSendIngMail_Click(object sender, EventArgs e)
        {
           StringBuilder stringBuilder = new StringBuilder();
            StringWriter writer = new StringWriter(stringBuilder);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            try
            {
                
                DivSendMail.RenderControl(htmlWriter);
            }
            catch (HttpException generatedExceptionName)
            {
                e.ToString();
            }
            try
            {
                string DefProductTemp_Html = stringBuilder.ToString();
                //send mail
                string smtpServer = Convert.ToString(DotNetNuke.Common.Globals.HostSettings["SMTPServer"]);
                string uid = Convert.ToString(DotNetNuke.Common.Globals.HostSettings["SMTPUsername"]);
                string upwd = Convert.ToString(DotNetNuke.Common.Globals.HostSettings["SMTPPassword"]);
              //  DotNetNuke.Services.Mail.Mail.SendMail(uid, txtMail.Text, uid, "Proforma Invoice", DefProductTemp_Html, "", DotNetNuke.Services.Mail.MailFormat.Html.ToString(), "", "", "", "");
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient client = new SmtpClient();
                mail.To.Add(txtMail.Text);
                mail.From = new System.Net.Mail.MailAddress(uid);
                mail.Subject = ddlSubList.SelectedItem.Text;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Body = DefProductTemp_Html;
                //mail.BodyEncoding = System.Text.Encoding.UTF8;
                //mail.Priority = System.Net.Mail.MailPriority.High;
                client.Credentials = new System.Net.NetworkCredential(uid, upwd);
                //client.Host = "localhost";
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(mail);
            }
            catch (Exception ex)
            {
               // catch
            }
