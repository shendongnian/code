    bool SendEmail(string subject, string message, Attachment attachment)
    {
    	try
    	{
    		SmtpClient smtpClient = CreateProductionSMTPClient();
    		MailMessage msg = new MailMessage();
    		msg.Subject = subject;
    		msg.Body = message;
    		msg.To.Add(ConfigurationHelper.EmailTo);
    		msg.From = new MailAddress(ConfigurationHelper.EmailFrom);
    		msg.BodyEncoding = Encoding.UTF8;
    		
    		//commented line cause the problem
            // msg.Headers.Add("Content-Type", "text/html");
            //instead of that use next line
            msg.IsBodyHtml = true;
    		
    		if (attachment != null)
    		{
    			msg.Attachments.Add(attachment);
    		}
    				
    		smtpClient.Send(msg);
    		return true;
    	}
    	catch (Exception ex)
    	{
    		return false;
    	}
    }
    
    //Attachment building
    Attachment WrapExcelBytesInAttachment(byte[] excelContent)
    {
    	try
    	{
    		Stream stream = new MemoryStream(excelContent);
    		Attachment attachment = new Attachment(stream, "fileName.xls");
    		attachment.ContentType = new ContentType("application/vnd.ms-excel");
    		return attachment;
    	}
    	catch (Exception ex)
    	{
    		return null;
    	}
    }
     
      
       
