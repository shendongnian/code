    private string DateGuid()
        {
            string pre = "Ugly Users -";
            return pre + Guid.NewGuid();
        }
    // POST: /Account/Register
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]    
    public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { Id = DateGuid() };
                var result = await UserManager.CreateAsync(user, model.Password);
    ...
