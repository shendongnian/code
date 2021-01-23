        //
        // GET: /AjaxTest/
        public ActionResult Index()
        {
            var model = new DropDownModel(new List<string>
            {
                "Option A",
                "Option B"
            });
            return View(model);
        }
        public PartialViewResult GetDataForDiv(string selectedOption)
        {
            var model = new ConditionalsModel(selectedOption);
            return PartialView("Conditionals", model);
        }
    }
