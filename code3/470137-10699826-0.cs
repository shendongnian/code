       void imageSave(System.Drawing.Image imageTobeSaved)
        {
            using (SPSite site = new SPSite("http://sptestsite/"))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPFolder myLibrary = web.Folders["Shared%20Documents"];
    
                   
                    var stream = new System.IO.MemoryStream();
                    string filename = "picture.jpg";          
                    MemoryStream ms = new MemoryStream();
                    imageTobeSaved.Save(ms, System.Drawing.Imaging.ImageFormat.jpg);
                    byte[] ImageByte = ms.ToArray();
                    
                    SPFile spfile = myLibrary.Files.Add(filename, ImageByte);
                    myLibrary.Update();
    
    
                }
            }
        }
