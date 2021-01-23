     public string GetImageDetails(int ID)
     {
         var img = Image.FromFile(<path to image on server>);
         var serializer = new JavaScriptSerializer();
         return serializer.Serialize(new { width = img.Width, height = img.Height });
     }
