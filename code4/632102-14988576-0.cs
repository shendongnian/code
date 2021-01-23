    // model
    public class UploadedImage
    {
        public int UploadedImageID { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }
    }
    // controller
    public ActionResult Create()
    {
        HttpPostedFileBase file = Request.Files["ImageFile"];
    	if (file.ContentLength != 0)
        {
            UploadedImage img = new UploadedImage();
            img.ContentType = file.ContentType;
            img.File = new byte[file.ContentLength];
            
            file.InputStream.Read(img.File, 0, file.ContentLength);
	
            db.UploadedImages.Add(img);
            db.SaveChanges();
        }
        
        return View();
    }
    ActionResult Show(int id) 
    {
        var image = db.UploadedImages.Find(id);
        if (image != null)
        {
            return File(image.File, image.ContentType, "filename goes here");
        }
    }
