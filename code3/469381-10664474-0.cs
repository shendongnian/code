        [HttpPost]
        public ActionResult Index(FormCollection collection, List<Bet> bets)
        {
            var user = User.Identity.Name;
            var model = _db.Bets.Where(t => t.Better== user);
            int i = 0;
            foreach (var bet in model)
            {
                bet.GoalsHome = bets[i].GoalsHome;
                bet.GoalsGuest= bets[i].GoalsGuest;
                i++;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
