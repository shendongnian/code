        public ActionResult NameofDetailsView(int id)
        {
            Show s = new Show();
            s.PostId = id;
            return View(s);
        }
