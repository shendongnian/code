        private readonly IOrchardServices _services;
        public PlayerManagementController(IOrchardServices services) {
            _services = services;
        }
        [HttpGet]
        public ActionResult PlayerSearch()
        {
            var playerSearchType = _services.ContentManager.Query().ForType(new[] {"PlayerSearch"}).Slice(0, 1).FirstOrDefault();
            var model = _services.ContentManager.BuildEditor(playerSearchType);
            // Casting to avoid invalid (under medium trust) reflection over the protected View method and force a static invocation.
            return View((object)model);
        }
