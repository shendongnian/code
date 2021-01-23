        [HttpPost]
        public ActionResult MyMethod(string b1, string b2, string b3)
        {
            if (b1 != null)
            {
                return Button1Click();
            }
            else if (b2 != null)
            {
                return Button2Click();
            }
            else
            {
                return Button3Click();
            }
        }
        public ActionResult Button1Click()
        {
            return View();
        }
        public ActionResult Button3Click()
        {
            return View();
        }
        public ActionResult Button2Click()
        {
            return View();
        }
