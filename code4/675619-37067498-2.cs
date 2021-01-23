        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FirstAjax(string a)
        {
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }   
