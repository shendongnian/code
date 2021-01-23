    [Authorize]
    [HttpPost]
        public ActionResult Create(ExpenseModel expense)
        {            
            if (ModelState.IsValid)
            {
                UserProfile user = db.UserProfiles.Single(u => u.UserName == User.Identity.Name)
                _expense = new Expense() { Name = expense.Name, Limit = expense.Limit, UserProfile = user };
                user.Expenses.Add(_expense);                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            return View(expense);
        }
