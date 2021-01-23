    void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
    	this.Application.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(DocumentSave);
    }
    
    void DocumentSave(Word.Document doc, ref bool test, ref bool test2)
    {
    	if(doc is Word.Document)
    	{                
    		SendMailWithAttachment(doc);
    	}
    }
    
    public void SendMailWithAttachment(Word.Document doc)
    {
    	SmtpClient smtpClient = new SmtpClient();
    	NetworkCredential basicCredential = new NetworkCredential(MailConst.Username, MailConst.Password);
    	MailMessage message = new MailMessage();
    	MailAddress fromAddress = new MailAddress(MailConst.Username);
    
    	// setup up the host, increase the timeout to 5 minutes
    	smtpClient.Host = MailConst.SmtpServer;
    	smtpClient.UseDefaultCredentials = false;
    	smtpClient.Credentials = basicCredential;
    	smtpClient.Timeout = (60 * 5 * 1000);
    
    	message.From = fromAddress;
    	message.Subject = subject;
    	message.IsBodyHtml = false;
    	message.Body = body;
    	message.To.Add(recipient);
    	
    	var attachmentFilename = doc.FullName
    
    	if (attachmentFilename != null)
    	{
    		Attachment attachment = new Attachment(attachmentFilename, MediaTypeNames.Application.Octet);
    		ContentDisposition disposition = attachment.ContentDisposition;
    		disposition.CreationDate = File.GetCreationTime(attachmentFilename);
    		disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
    		disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
    		disposition.FileName = Path.GetFileName(attachmentFilename);
    		disposition.Size = new FileInfo(attachmentFilename).Length;
    		disposition.DispositionType = DispositionTypeNames.Attachment;
    		message.Attachments.Add(attachment);                
    	}
    
    	smtpClient.Send(message);
    }
