        public ActionResult Index()
        {  
            // div "mudetails" should not apper
            return View(false);
        }
        public ActionResult Index(string textbox)
        {
           // div "mudetails" should apper
           return View(true);
        }
