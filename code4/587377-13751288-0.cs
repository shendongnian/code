	public System.Net.Mail.AlternateView GenerateHTMLErrorEmail(Exception ex)
	{
		string body = ProductionEmailer.Properties.Resources.ShippedEmail;
		//Build replacement collection to replace fields in email.html file
		body = body.Replace("%MESSAGE%", ex.Message);
		
		AlternateView html = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
		
		//add a image to the html email, optional
		Bitmap b = new Bitmap(Properties.Resources.html_email_header_01);
		ImageConverter ic = new ImageConverter();
		Byte[] ba = (Byte[])ic.ConvertTo(b, typeof(Byte[]));
		MemoryStream logo = new MemoryStream(ba);
		LinkedResource header1 = new LinkedResource(logo, "image/gif");
		header1.ContentId = "header1";
		html.LinkedResources.Add(header1);
		return html;
	}
