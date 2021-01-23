    if(geckoWebBrowser1.CopyImageContents())//if image contents can be copied...
    {
        System.Drawing.Image img = Clipboard.GetImage();//copy image into variable
        
        //here you can use a folder browser dialog to locate path manualy
        img.Save(Application.StartupPath + "tempImg.jpg");//will save image to path
        
        //last two lines is optional and can open same image in default image preview program
        string fak = Application.StartupPath + "tempImg.jpg";
        System.Diagnostics.Process.Start(fak);
    }
