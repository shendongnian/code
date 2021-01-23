    // might need to change to HttpPostedFileBase[] for multiple file uploads
    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase, string photoName) 
    {
       var stream = httpPostedFileBase.InputStream;
       var photo = new Photo { Name = photoName };
       repository.Save(photo);
       s3service.Upload(stream, photo.Id);
    }
