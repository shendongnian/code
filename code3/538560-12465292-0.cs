    using (var db = new EzPrintsEntities())
    {
    	var image = db.Images.SingleOrDefault(i => i.Id == id); // Assuming Id is the PK on Image, and we sent in the PK in a variable called id.
    	if (image != null)
    	{
    		image.Label = newName;
    		image.Path = newPath;
    		
    		db.SaveChanges();
    	}
    	else
    	{
    		// Invalid PK value sent in, do something here (logging, error display, whatever).
    	}
    }
