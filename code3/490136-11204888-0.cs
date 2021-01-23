    public class HomeController
    {
        public ActionResult Image( int id )
        {
            var imageData = getImagebyte(); // your function to return image byte
    
            return File(imageData, "image/jpg");
        }
    }
