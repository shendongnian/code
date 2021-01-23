    Control myControl = new Control();
    string[] filePaths = Directory.GetFiles(@"c:\images\");
    
    foreach (string file in filePaths)
    {
        Image image = new Image();
        image.ImageUrl = file;
        myControl.Controls.Add(image);
    }
    
    Page.Controls.Add(myControl);
