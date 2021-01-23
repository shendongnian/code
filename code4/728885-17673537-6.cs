      for (int i = 1; i < dt.Rows.Count; i++)
      {
        try
        {
          string _ImageUrl = HttpContext.Current.Request.PhysicalApplicationPath +
              "Data\\" + dt.Rows[i]["ProductImage"].ToString();
          string _extName = System.IO.Path.GetExtension(_ImageUrl);
          using (System.Drawing.Image _productImage = ImageReSize(_ImageUrl, 500))
          {
            string _path = _ImageUrl;
            if (System.IO.File.Exists(_path))
              System.IO.File.Delete(_path);
            _productImage.Save(_path);
          }
          using (System.Drawing.Image _productImage = ImageReSize(_ImageUrl, 85))
          {
            string _strImageName2 = dt.Rows[i]["ProductSmallImage"].ToString();
            _path = HttpContext.Current.Request.PhysicalApplicationPath +
                "Data\\" + _strImageName2;
            if (System.IO.File.Exists(_path))
              System.IO.File.Delete(_path);
            _productImage.Save(_path);
          }
        }
        catch
        {
          //Handle the exeption
        }
      }
    public System.Drawing.Image ImageReSize(string _imageUrl, int Width)
    {
      
      try
      {
        //uploadImageFile.PostedFile.InputSteam
        using (System.Drawing.Image oImg = System.Drawing.Image.FromFile(_imageUrl))
        //((oh *nw) / ow)*100
        {
          int Height = ((oImg.Height * Width) / oImg.Width);              // (oImg.Width * Width);
          Size PictureThumbSize = new Size();
          PictureThumbSize.Height = Height;
          PictureThumbSize.Width = Width;
          System.Drawing.Image oThumbNail = new Bitmap(PictureThumbSize.Width, PictureThumbSize.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
          using (Graphics oGraphic = Graphics.FromImage(oThumbNail))
          {
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, PictureThumbSize.Width, PictureThumbSize.Height);
            oGraphic.DrawImage(oImg, oRectangle);
          }
          return oThumbNail;
        }
        //oThumbNail.Save(sPhysicalPath + @"\" + newFileName, ImageFormat.Jpeg);
      }
      catch (Exception Ex)
      {
        return null;
      }
      
    }
