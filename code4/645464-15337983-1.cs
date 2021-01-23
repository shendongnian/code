        [HttpGet]
        public ActionResult Generate()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult PasswordGenerator(PasswordModel model) 
        {
           <nameofclass>.PasswordGenerator(model.Password.Length, model.StrongPassword);
        }
