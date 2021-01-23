    public bool SendEmail()
    {
    	bool status = false;
    
    		try
    		{
    			//code to send email
    			this._mail = new MailMessage();
    
    			this._mail.From = new MailAddress(this.From, this.DisplayName);
    
    			if (!string.IsNullOrEmpty(this.To))
    			{
    				var distinctAddress = new List<string>(this.To.Split(',').Distinct());
    				this.To = string.Empty;
    
    				foreach (string address in distinctAddress) // Loop through all strings
    				{
    					this.To += address + ","; // Append string to StringBuilder
    				}
    				this.To = this.To.TrimEnd(',');
    				this._mail.To.Add(this.To);
    			}
    
    			if (!string.IsNullOrEmpty(this.CC))
    				this._mail.CC.Add(this.CC);
    
    			if (!string.IsNullOrEmpty(this.BCC))
    				this._mail.Bcc.Add(this.BCC);
    
    			this._mail.Subject = this.Subject;
    
    			this._mail.IsBodyHtml = this.IsBodyHtml;
    
    			this._mail.Body = this.Body;
    
    			if (this.Priority == true)
    			{
    				this._mail.Priority = MailPriority.High;
    			}
    
    			this._mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    
    			if (this._attachments != null && this._attachments.Count > 0)
    			{
    				foreach (string file in this._attachments)
    				{
    					Attachment attachment = new Attachment(file);
    					this._mail.Attachments.Add(attachment);
    				}
    			}
    
    			this._smtpServer = new SmtpClient(this.EmailServer);
    			this._smtpServer.EnableSsl = this.EnableSsl;
    			this._smtpServer.Port = this.Port;
    			this._smtpServer.Credentials = new System.Net.NetworkCredential(this.UserId, this.Password);
    
    			if (String.IsNullOrEmpty(this.To) != true || string.IsNullOrEmpty(this.CC) != true || string.IsNullOrEmpty(this.BCC) != true)
    				this._smtpServer.Send(this._mail);
    			status = true;
    		}
    		catch (Exception ex)
    		{
    		}
    	return status;
    }
