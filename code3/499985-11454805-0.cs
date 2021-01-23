        private string SendMessage(string strTo, string strFrom, string strSubject, string strMessage, string strAttachment, string strBCC)
        {
            try
            {
                System.Net.Mail.MailMessage mailMsg;
                string strEmail = "";
                string strSmtpClient = ConfigurationManager.AppSettings["SmtpClient"];
                string[] arrEmailAddress = strTo.Split(';');
                for (int intCtr = 0; intCtr < arrEmailAddress.Length; intCtr++)
                {
                    strEmail = "";
                    if (arrEmailAddress[intCtr].ToString().Trim() != "")
                    {
                        strEmail = arrEmailAddress[intCtr].ToString().Trim();
                        mailMsg = new MailMessage(strFrom, strEmail, strSubject, strMessage);
                        mailMsg.IsBodyHtml = true;
                        if (!strBCC.Trim().Equals(string.Empty))
                            mailMsg.Bcc.Add(strBCC);
    
                        /*** Added mail attachment handling ***/    
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(strAttachment);
                        mailMsg.Attachments.Add(attachment);
                        SmtpClient smtpClient = new SmtpClient(strSmtpClient);
                        smtpClient.UseDefaultCredentials = true;
                        smtpClient.Port = 25;
    
                        smtpClient.Send(mailMsg);
                        mailMsg.Dispose();
                    }
                }
                return "Message sent to " + strTo + " at " + DateTime.Now.ToString() + ".";
            }
            catch (Exception objEx)
            {
                return objEx.Message.ToString();
            }
        }
    
        protected void Submit_Click1(object sender, EventArgs e)
        {
            try
            {
                /*** Moved from SendMessage function ****/
                string strUpLoadDateTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
                string strFileName1 = string.Empty;
                if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
                {
                    string strUploadFileName1 = File1.PostedFile.FileName;
                    strFileName1 = strUpLoadDateTime + "." + Path.GetFileNameWithoutExtension(strUploadFileName1) + Path.GetExtension(strUploadFileName1);
                    strFileName1 = strFileName1.Replace("'", "");
                    string strSaveLocation = Server.MapPath("") + "\\" + strFileName1;
                    File1.PostedFile.SaveAs(strSaveLocation);
                    txtComments.Text = "The file has been uploaded";
                }
    
                string dandt = System.DateTime.Now.ToString("yyyyMMddHHmmss");
                string strMessage = "Bug Name: " + txtBugName.Text.Trim() + "<br/>" +
                             "Module Name: " + ddlModule.SelectedValue + "<br/>" +
                             "Page Name: " + ddlPage.SelectedValue + "<br/>" +
                             "Description: " + txtComments.Text.Trim() + "<br/>" +
                              strSaveLocation + "<br/>" +
                              "Email is" + " " + txtemail.Text.Trim() + "<br/>" +
                              "The request was sent at" + dandt;
    
    
                SendMessage(ConfigurationManager.AppSettings["EmailAddrTo"],
                    ConfigurationManager.AppSettings["EmailAddrFrom"],
                    txtBugName.Text.Trim(),
                    strMessage, strSaveLocation, "");
            }
            catch
            {
            }
        }
