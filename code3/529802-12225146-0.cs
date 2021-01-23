      // GET: /Membership/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            var recordToEdit = (from r in _db.vw_aspnet_Users where r.UserId == id select r).First();
            return View(recordToEdit);
        }
        public ActionResult Index()
        {
            return View(_db.vw_aspnet_MembershipUsers.ToList());
        }
