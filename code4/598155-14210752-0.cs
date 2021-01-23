    string base64 = item.UserIMG;
    if (item.UserIMG != null) // If there's actually a string inside item.UserIMG
    {
        System.IO.Stream s = new MemoryStream(Convert.FromBase64String(base64));
        byte[] arr = Convert.FromBase64String(base64);
        Drawable img = Drawable.CreateFromStream(s, null);
        ImageView UserAvatar = view.FindViewById<ImageView>(Resource.Id.imgView);
        UserAvatar.SetImageDrawable(img);
     }
     else  // If item.UserIMG is "" or null
        {
           ImageView UserAvatar = view.FindViewById<ImageView>(Resource.Id.imgView);
        }   
