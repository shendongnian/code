        public ActionResult Index()
        {
            // Key if statement to make sure the area maps correctly
            if (!this.ControllerContext.RouteData.DataTokens.ContainsKey("area"))
            {
                this.ControllerContext.RouteData.DataTokens.Add("area", "Test");
            }
            return View("Test");
        }
