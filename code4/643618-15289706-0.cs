     public ActionResult Index()
     {
           var user = db.UserProfiles.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
           var allCategories = db.ProfitCategories
               .Where(x => x.IdUser.UserId==user.UserId)
