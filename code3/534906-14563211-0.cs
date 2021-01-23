    public void Sender()
        {
            if (Globalcls.Message_list.Count == 0)
                return;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(Globalcls.settings.username, Globalcls.settings.password);
            client.Port = Convert.ToInt32(Globalcls.settings.portS);
            
            client.Host = "smtp.xdsl.co.za";
            client.SendCompleted += new SendCompletedEventHandler(MailSendCallback);
            if (Globalcls.Message_list.Count > 0)
            {
                try
                {
                    client.SendAsync(Globalcls.Message_list[0].msg, "1");
                    
                }
                catch (Exception ex)
                {
                    //do exception stuff here, only cut here to make post shorter
                }
            }
     static void MailSendCallback(object sender, AsyncCompletedEventArgs arg)
        {
            // oncomllete event for async send.
            if (arg.Error != null)
            {
                //mail did not send, here I do not remove it and increment an counter so  to delete a mail that keeps failing
            }
            else
            {
                Form1 frm1 = new Form1(); 
                frm1.que("email sent to " + Globalcls.projects[Globalcls.Message_list[0].project].name);
                frm1.Dispose();
                Globalcls.Message_list[0].msg.Dispose();
                foreach (string meh in Globalcls.Message_list[0].files)
                    File.Delete(meh);
                Globalcls.Message_list.RemoveAt(0);
            }
            if (Globalcls.Message_list.Count > 0)
            {
                Form1 frm2 = new Form1();
                frm2.Sender();
                frm2.Dispose();
        }
