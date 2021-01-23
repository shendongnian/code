    public ActionResult Index()
    {
            var imageFiles = new ImageModel();
            imageFiles.Images.AddRange(System.IO.Directory.GetFiles(@"C:\wherever\files\are\"));
            for (int i = 0; i < imageFiles.Images.Count; i++)
            {
                // get rid of the fully qualified path name
                imageFiles.Images[i] = imageFiles.Images[i].Replace(@"C:\wherever\files\are\", "");
                // change the slashes for web
                imageFiles.Images[i] = imageFiles.Images[i].Replace('\\','/');
            }
            return View(imageFiles);
    }
