    public ActionResult Area51()
        {
            var _service = DependencyResolver.Current.GetService(typeof (IDummyService));
            return View();
        }
