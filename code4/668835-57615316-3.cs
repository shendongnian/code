    Bitmap bmp = ScreenShotaControl(aControl);
        Clipboard.SetImage(bmp); //to copy to clipboard
    
    Bitmap bmp = ScreenShotaControl(aControl);
        bmp.Save(@"C:\MyPanelImage.bmp"); //save to specified path
    Bitmap bmp = ScreenShotaControl(aControl);
        MemoryStream ms= new MemoryStream();
        bmp.Save(ms, ImageFormat.Jpeg); 
        ContentType ct= new ContentType(); 
        ct.MediaType = MediaTypeNames.Image.Jpeg; 
    
        MailMessage mail = new MailMessage(); 
        mail.Attachments.Add(new Attachment(ms, ct));  //attach to email
