    public class ImagesController: Controller
    {
        public ActionResult SomeImage(string imageName)
        {
            var file = Path.Combine(@"C:\Images\", imageName);
            return File(file, "image/jpeg");
        }
    }
