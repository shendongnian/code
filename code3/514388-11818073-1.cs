    public class CompaniesController: Controller
    {
        public ActionResult Index()
        {
            List<Company> companies = getCompanies();
            var model = new MyViewModel();
            model.Companies = companies.Select(x => new SelectListItem
            {
                Value = x.companyID,
                Text = x.companyName
            });
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // model.CompanyId will contain the selected value here
            return Content(
                string.Format("You have selected company id: {0}", model.CompanyId)
            );
        }
    }
