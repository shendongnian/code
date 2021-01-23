    public class ImagesController : Controller
    {
        public ViewResult ShowImages()
        {
            Image image = new Image();
            return View(image);
        }
    }
