        public ActionResult Index()
        {  
            ViewBox.ShowDetails = false;
            return View();
        }
        public ActionResult Index(string textbox)
        {
               ViewBox.ShowDetails = true;
        }
