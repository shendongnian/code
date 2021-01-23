    public Unit GetImageHeight(string ImageName)
    {
        int height= 0;
        if (System.IO.File.Exists(Server.MapPath(GetImageUrl(ImageName))
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath(GetImageUrl(ImageName)));
            if (img.Width > 1000)                      
               height = 535;        
            else
                height= img.height;
            img.Dispose();
        }
        return Unit.Pixel(height);
     }
