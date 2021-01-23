        [Authorize]
        public ActionResult Edit()
        {
            var userId = (Guid)Membership.GetUser().ProviderUserKey;
            var someService = new MyService();
            var someData = someService.GetSomeDataByUserId(userId);
            //...
        }
