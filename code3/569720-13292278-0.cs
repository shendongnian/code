     public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View(new SignUpModel
                                {
                                    Common = new Common(),
                                    Personal = new Personal(),
                                    Company = new Company()
                                });
            }
    
    
    
            [HttpPost]
            [SignUpSelector]
            [ActionName("Index")]
            public ActionResult PersonalRegistration(Personal personal, Common common)
            {
                if (ModelState.IsValid)
                {
                    //your code
                }
                return View("Index", new SignUpModel()
                                         {
                                             Common = common,
                                             Personal = personal,
                                             Company = new Company()
                                         });
            }
    
            [HttpPost]
            [SignUpSelector]
            [ActionName("Index")]
            public ActionResult CompanyRegistration(Company company, Common common)
            {
                if(ModelState.IsValid)
                {
                    //your code
                }
                return View("Index", new SignUpModel()
                                         {
                                             Common = common,
                                             Personal = new Personal(),
                                             Company = company
                                         });
            }
    
    
        }
