    System.Drawing.Image image = Image.FromFile(@"Q:\my_image.tif");
    System.Drawing.Imaging.ColorPalette palette = image.Palette;
    //...palette.Entries is simply an array of System.Drawing.Color, modify to suit
    
    //crucial step - palette was retrieved as a copy, so
    //it is necessary to store the copy back to the image
    image.Palette = palette;
