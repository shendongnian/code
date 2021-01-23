    [HttpPost]
        public ActionResult Index(IEnumerable<yourViewModel> items)
        {
             if(ModelState.IsValid)
              {
                //do with items. (model is passed to the action, when you submit)
              }
        } 
