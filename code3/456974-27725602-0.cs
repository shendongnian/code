     [HttpPost]
     public string MyFileUpload()
     {            
         var filePath = "C:\\temp\\myfile.txt";
         using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
         {                   
             HttpContext.Current.Request.InputStream.CopyTo(fs);
         }
         return "file uploaded";
     }
