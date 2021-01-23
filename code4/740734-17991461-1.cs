     public ActionResult Index( TextBoxGrid model)
        {
            var viewModel = new ParentViewModel
            {
                TextBoxGrid = new TextBoxGrid { employees = GetEmployee().ToList()}
                //but first change TextBoxGrid Property from emplyees to employees{get;set;}
            }
            return View(viewModel);
        }
