        [HttpGet]
        public ActionResult Create()
        {
          PopulateCategoriesDropDownList();
        return View();
       }
        [HttpPost]
        [InitializeSimpleMembership]
        public ActionResult Create(Profits profits)
        {
             var user = db.UserProfiles.FirstOrDefault(x => x.UserId ==       WebSecurity.CurrentUserId);
            var profit = new Profits
            {
               Value= profits.Value,
               Description = profits.Description,
               DateInput =profits.DateInput,
               CategoryName =profits.CategoryName,// ???
                User = user,
            };
            db.Profits.Add(profit);
            db.SaveChanges();
            PopulateCategoriesDropDownList(user.CategoryId);
           return View(user);
        }
