        Bitmap _icon;
        try
        {
         _icon = new Icon(icon, width, height).ToBitmap();
        }
        catch(ArgumentOutOfRangeException)
        {
         _icon = Bitmap.FromHicon(new Icon(icon, new Size(width, height)).Handle);
        }
