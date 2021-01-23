    class MyController
    {
        private readonly ISession _session;
        public MyController(ISession session = null)
        {
            _session = session ?? HttpContext.Session;
        }
        public IActionResult Action1()
        {
            _session.SetString("Key", "Value");
            View();
        }
        public IActionResult Action2()
        {
            ViewBag.Key = _session.GetString("Key");
            View();
        }
    }
