    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    protected void bttn_Send_Click(object sender, EventArgs e)
    {
    string from = “info@suryarpraveen-wordpress.com”;
    string textTo = “careers@suryarpraveen-wordpress.com”;
    using (MailMessage mail = new MailMessage(from, textTo))
    {
    
    mail.Subject = “Careers – Surya R Praveen WordPress”;
    
    mail.Body = string.Format(@”
    Name: {0}
    Email: {1}
    Contact: {2}
    Job: {3}
    Experience: {4}
    “, txtName.Text, txtEmail.Text, txtcontact.Text, txtjobTitle.SelectedItem.Text, txtjobExp.SelectedItem.Text);
    
    if (fileUploader.HasFile)
    {
    string fileName = Path.GetFileName(fileUploader.PostedFile.FileName);
    mail.Attachments.Add(new Attachment(fileUploader.PostedFile.InputStream, fileName));
    }
    mail.IsBodyHtml = false;
    SmtpClient smtp = new SmtpClient();
    smtp.Host = “mail.suryarpraveen-wordpress.com”;
    smtp.EnableSsl = false;
    NetworkCredential networkCredential = new NetworkCredential(from, “password@007”);
    smtp.UseDefaultCredentials = true;
    smtp.Credentials = networkCredential;
    smtp.Port = 25;
    smtp.Send(mail);
    ClientScript.RegisterStartupScript(GetType(), “alert”, “alert(‘Message has been sent successfully.’);”, true);
    }
    }
    }
