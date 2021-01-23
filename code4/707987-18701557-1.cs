        [HttpPost]
        public ActionResult Index(ViewModelCCTRST model)
        {
            if (ModelState.IsValid)
            {
                string pro = model.Prospects;
                string cnt = model.Countys;
                string twn = model.TownShips;
                string rng = model.Ranges;
                string sct = model.Sections;
                string trt = model.Tracts;
