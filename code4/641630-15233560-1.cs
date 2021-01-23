    public ActionResult Create(Profits profits)
            {
                var user = db.UserProfiles.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
                var category = db.Categories.FirstOrDefault(o => o.CategoryId == profits.CategoryID);
                var profit = new Profits
                {
                   Value= profits.Value,
                   Description = profits.Description,
                   DateInput =profits.DateInput,
                   CategoryName = category,
                   User = user
                };
                db.Profits.Add(profit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
