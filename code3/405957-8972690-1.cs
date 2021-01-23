    public class HomeController : Controller
    {
        private readonly IPhotosRepository _repository;
        public HomeController(IPhotosRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Photo(int photoId)
        {
            return new PhotoResult(photoId, _repository.GetPhoto, "image/jpg");
        }
    }
