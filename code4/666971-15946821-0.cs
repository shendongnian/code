        public ActionResult TestA(MyViewModel vm)
        {
            ViewBag.SomeInt = vm.someint;
            ViewBag.SomeString = vm.somestring;
            return View();
        }
        public ActionResult TestB()
        {
            ViewBag.UrlToCall = Url.Action("TestA", new { someint=2, somestring="Oh Crap Crap Crap"});
            return View();
        }
