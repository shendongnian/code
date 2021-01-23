        [HttpPost]
        public ActionResult Index(HttpPostedFileBase f)
            {
                var m = new HomeModel();
                ..// Other code goes here
                return View(m);
            }
