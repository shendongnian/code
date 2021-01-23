        public ActionResult Login(string returnUrl)
        {
            int EventID = 0;
            int.TryParse(Regex.Match(returnUrl, "[^/]+$").ToString(), out EventID);
            ....
        }
