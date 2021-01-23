    public ActionResult Index() {
        PeopleViewModel model = new PeopleViewModel {
            EmailAddress = new List<string> {
                "ValueOne",
                "ValueTwo"
            }
        };
        return View(model);
    }
    
    [HttpPost]
    public ActionResult Index(PeopleViewModel model) {
        return View(model);
    }
