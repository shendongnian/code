    foreach (FileInfo fi in finfos)
    {
    	string ext = fi.Extension.ToLower();
    	if ((ext.Equals(".png")) || (ext.Equals(".jpg")) || (ext.Equals(".tif")) || (ext.Equals(".gif")))
    	{
    		try 
            {
    		    string Filename = fi.FullName;
    		    Image image = Bitmap.FromFile(Filename); //exception occurs HERE
    		    images.Add(image);
    		    //this.imageList1.Images.Add(image);
    		    //image.Dispose();
    		}
    		catch {}
    	}
    } 
