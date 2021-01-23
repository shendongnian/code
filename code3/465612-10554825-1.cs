        public ActionResult MyView()
        {
            TestModel m = new TestModel();
            m.Gender = "Female";
            return View(m);
        }
