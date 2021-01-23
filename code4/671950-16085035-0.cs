    class ImageLibrary
    }
    	public ActionResult List()
    	{
    		//I'm going to assume here you have some sort of service or repository for obtaining your images at this point.
    		//This doesn't retrieve the actual image data, just the metadata. It's less of a hit on the DB this way
    		var imagesList = imageService.ListAllImages()
    		IEnumerable<int> imageIds = imagesList.Select(x=>x.ImageId)
    		return View("List", imageIds)
    	}
    
    	public ActionResult View(int imageId)
    	{
    		var image = imageService.GetImage(imageId);
    
    		var contentDisposition = new System.Net.Mime.ContentDisposition() { FileName = image.Name, Inline = true };
    		Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
            return File(image.Data, image.ContentType); //including content type since I'm assuming the image could be a jpg, gif, png, etc./
    	}
    
    }
