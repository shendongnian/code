        [HttpPost]
        public ActionResult Index(FormCollection collection, List<Bet> bets)
        {
            var user = User.Identity.Name;
            var model = _db.Bets.Where(t => t.Better== user);
            int i = 0;
            foreach (var bet in model)
            {
                Bet the_Bet= bets.Find(
                    delegate(Bet _bet)
                    {
                        return _bet.BetID == bet.BetID;
                    });
                bet.GoalsHome= the_Bet.GoalsHome;
                bet.GoalsGuest= the_Bet.GoalsGuest;
                i++;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
