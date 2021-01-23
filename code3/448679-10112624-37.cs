    public class BrandsController: Controller
    {
        private readonly IBrandsRepository _repository;
        public BrandsController(IBrandsRepository repository)
        {
            _repository = repository;
        }
    
        public ActionResult Index()
        {
            var brands = _repository.Get();
            var model = new BrandsViewModel
            {
                Brands = Mapper.Map<IEnumerable<Brand>, IEnumerable<SelectListItem>>(brands)
            };
            return View(model);
        }
    }
