    protected void btnSendNewsLetter_Click(object sender, EventArgs e)
    {
        //snip
        //Create the smtp client to send the mails with.
        SmtpClient client = new SmtpClient(server);
        // Add credentials if the SMTP server requires them.
        client.Credentials = CredentialCache.DefaultNetworkCredentials;
        if(ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
            {
                string email = ds1.Tables[0].Rows[i].ItemArray[0].ToString();
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                //snip
                try 
                {
                    client.Send(message);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());			  
                }
            }
        }
    }
