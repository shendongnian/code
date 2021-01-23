        [HttpPost]
        public ActionResult Index(Thing myThing) {
            if (ModelState.IsValid) {
                //Do some work in here because we're all good
                return RedirectToAction("MyOtherAction");
            }
            //Oops the validation failed so drop back to the view we came from
            return View();
        }
