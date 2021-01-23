    MemoryStream ms = new MemoryStream();  
            this.FUImage.PostedFile.InputStream.CopyTo(ms);   
            var bytes = ms.ToArray();   
            ms.Close();   
            var image = new Image()   
            {   
                Name = this.FUImage.PostedFile.FileName,   
                FileBinary = bytes   
            };  
    
    
    
     using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))  
            {
                using (BinaryWriter w = new BinaryWriter(fs))  
                {  
                    for (int i = 0; i < 11; i++)  
                    {  
                        w.Write(bytes);  
    
                    }  
                }  
            }  
