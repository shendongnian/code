    public class ImagesController: Controller
    {
        public ActionResult SomeImage(string imageName)
        {
            var root = @"C:\Images\";
            var path = Path.Combine(root, imageName);
            path = Path.GetFullPath(path);
            if (!path.StartsWith(root))
            {
                // Ensure that we are serving file only inside the root folder
                // and block requests outside like "../web.config"
                throw new HttpException(403, "Forbidden");
            }
 
            return File(path, "image/jpeg");
        }
    }
