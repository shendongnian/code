        [FacebookAuthorize("email", "user_photos", "user_likes")]
        public async Task<ActionResult> Index(FacebookContext context)
        {
            ...
        }
