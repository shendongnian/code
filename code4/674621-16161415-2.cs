    namespace Applicationrootns.Controllers
    {
        public class StudentController : Controller
        {
            public ActionResult Index()
            {
                var products = productsRepository.GetProducts();
                return View(products);
            }
        }
    }
    namespace Applicationrootns.Controllers.Api
    {
        public class StudentController : ApiController
        {
            public IEnumerable<Product> Get()
            {
                return productsRepository.GetProducts();
            }
        }
    }
