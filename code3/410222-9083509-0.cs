	AlternateView htmlView = AlternateView.CreateAlternateViewFromString(model.MessageBody_Html, null, MediaTypeNames.Text.Html);
	ImgStream	= new MemoryStream(media.MediaData); 
	linkedImage	= new LinkedResource(ImgStream, MediaTypeNames.Image.Jpeg);
	linkedImage.ContentId	 = "img_" + media.MediaID;
	linkedImage.TransferEncoding	= TransferEncoding.Base64;
	htmlView.LinkedResources.Add(linkedImage);
