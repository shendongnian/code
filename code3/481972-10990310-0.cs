    public FileResult GetImg(int id)
        {                       
             var image = db.Categories.First(m => m.CategoryID == id).Picture;
        
             byte[] imageData;
             if(image != null)
             {
                 imageData = image.ToArray();
                 return File( imageData, image.contentType );
             }
             else
             {
                 return null;
             }
         }
