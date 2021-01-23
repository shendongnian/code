        public bool send(string sImagePath)
        {
            if (account == null)
                return false;
            try
            {
                eMail = new EmailMessage();
                rcp = new Recipient(_to);
                eMail.To.Add(rcp);
                eMail.Subject = "Visitenkarten";
                eMail.BodyText = "VCard " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\r\nsent from eMDI2Mail";
                attachement = new Attachment(sImagePath);
                eMail.Attachments.Add(attachement);                
                eMail.Send(account);                
                //account.Send(eMail);
                if (this._syncImmediately)
                {
                    if (this.account != null)
                        Microsoft.WindowsMobile.PocketOutlook.MessagingApplication.Synchronize(this.account);
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in send(): " + ex.Message);
            }
            return false;
        }
