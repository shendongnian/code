    public class BrandsController: Controller
    {
        private readonly IBrandsRepository _repository;
        public BrandsController(IBrandsRepository repository)
        {
            _repository = repository;
        }
    
        public ActionResult Index()
        {
            var brands = _repository.Get().Select(b => new SelectListItem
            {
                Value = b.Id,
                Text = b.Name
            });
            var model = new BrandsViewModel
            {
                Brands = brands
            };
            return View(model);
        }
    }
