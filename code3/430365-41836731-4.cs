    class MyController
    {
        private readonly ISession _session;
        public MyController(ISession session = null)
        {
            _session = session;
        }
        public IActionResult Action1()
        {
            Session().SetString("Key", "Value");
            View();
        }
        public IActionResult Action2()
        {
            ViewBag.Key = Session().GetString("Key");
            View();
        }
        private ISession Session()
        {
            return _session ?? HttpContext.Session;
        }
    }
