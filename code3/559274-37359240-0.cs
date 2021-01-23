        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(EmailResponse response)
        {
            if(ModelState.IsValid){
                return View("Thanks", response);
            }
            else
            {
                return View();
            }
        }
