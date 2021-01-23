        [HttpGet]
        public ActionResult CreateSuppo(int supportItemId)
        {
            var model = new CreateSupportItemViewModel ();
            model.SupportItemId= supportItemId;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CreateSupportItemViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var father= db.Fathers.Single(d => d.Id == viewModel.SupportItemId);
                var supportItem= new SupportItem();
                supportItem.Name = viewModel.Name;
                ....................
                .................
                father.SupportItems.Add(supportItem);
                db.SaveChanges();               
            }
            return View(viewModel);
        }
