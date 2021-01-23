    public class ImagesController: Controller
    {
        public ActionResult SomeImage()
        {
            return File(@"C:\Images\foo.jpg", "image/jpeg");
        }
    }
