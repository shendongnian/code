    I used below logic while saving a .png format. This is to ensure the file is already existing or not.. if exist then saving it by adding 1 in the filename
      
    string path="D:\\foldername\\filename.png";
    	    int Count=0;
                if (System.IO.File.Exists(path))
                {
                    do
                    {
                        path = "D:\\foldername\\filename+"_"+ ++Count + ".png";                    
                    } while (System.IO.File.Exists(path));
                }
              
                btImage.Save(path, System.Drawing.Imaging.ImageFormat.Png);
