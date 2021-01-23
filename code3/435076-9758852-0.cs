    var Photos = new List<Photo>(); 
    
    foreach (var image in Images) 
    { 
       if(image.ContentLength > 0)
       {
          Photo p = new Photo(); 
          p.ImageMimeType = image.ContentType; 
          p.ImageData = new byte[image.ContentLength]; 
          image.InputStream.Read(p.ImageData, 0, image.ContentLength); 
     
          Photos.Add(p); 
       }
    }
