    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Net.Mail;
    
    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(txtTo.Text);
            mail.From = new MailAddress(txtFrom.Text);
            mail.Subject = txtSubject.Text;
            mail.Body = txtMessage.Text;
            mail.IsBodyHtml = true;
    
            //Attach file using FileUpload Control and put the file in memory stream
            if (FileUpload1.HasFile)
            {
                mail.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("email@domain.com", "YourGmailPassword");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
    
        }
    }
