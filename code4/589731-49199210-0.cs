    try
    {
       var req = WebRequest.Create(photoUrl);
       using (var response = req.GetResponse())
       {
         using (var stream = response.GetResponseStream())
         {
           if (stream != null)
           {
             var image = Image.FromStream(stream);
           }
         }
       }
     }
     catch (Exception ex)
     {
       // handle exception
     }
