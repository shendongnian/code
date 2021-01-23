	// we need to use the prefix 'cid' in the img src value
	string emailReadyHtml = string.empty;
	emailReadyHtml += "<p>Hello World, below are two embedded images : </p>";
	emailReadyHtml += "<img src=\"cid:yasser\" >";
	emailReadyHtml += "<img src=\"cid:smile\" >";
	MailMessage mailMessage = new MailMessage();
    mailMessage.To.Add("yasser@mail.yy");
    mailMessage.From = new MailAddress("info@mail.yy", "Info");
	mailMessage.Subject = "Test Mail";
	mailMessage.IsBodyHtml = true;
	string image1Path = HttpContext.Current.Server.MapPath("~/Content/images/yasser.jpg");
	byte[] image2Bytes = someArrayOfByte;
	ContentType c = new ContentType("image/jpeg");
	// create image resource from image path using LinkedResource class.
	LinkedResource linkedResource1 = new LinkedResource(imagePath);
	linkedResource1.ContentType = c ;
	linkedResource1.ContentId = "yasser";
	linkedResource1.TransferEncoding = TransferEncoding.Base64;
	// the linked resource can be created from bytes also, which may be stored in database (which was my case)
	LinkedResource linkedResource2 = new LinkedResource(new MemoryStream(image2Bytes));
	linkedResource2.ContentType = c;
	linkedResource2.ContentId = "smile";
	linkedResource2.TransferEncoding = TransferEncoding.Base64;
		
	AlternateView alternativeView = AlternateView.CreateAlternateViewFromString(emailReadyHtml, null, MediaTypeNames.Text.Html);
	alternativeView.ContentId = "htmlView";
	alternativeView.TransferEncoding = TransferEncoding.SevenBit;
	alternativeView.LinkedResources.Add(linkedResource1) ;
	alternativeView.LinkedResources.Add(linkedResource2);
	mailMessage.AlternateViews.Add(alternativeView);
	SmtpClient smtpClient = new SmtpClient();
	smtpClient.Send(mailMessage);
