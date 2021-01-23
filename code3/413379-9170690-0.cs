    class ImageContent
    {
       public ActionMethod Image(int? id = 0)
       {
            // Get byte from table by image id
            ....
    
            
            return Content(byteArray.ToString(), "image/png");
       }
    }
