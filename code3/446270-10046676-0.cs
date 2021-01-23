        public ActionResult Edit(int id)
        {
            //See if this review id was created by the current user
            if(!db.tblReviews.Any(UserInfo => UserInfo.UserName.Equals(User.Identity.Name) && UserInfo.Id == id))
            {
                //Redirect the user away from this edit page, they can't edit this one.
            }
            tblReview tblreview = db.tblReviews.Find(id);
            ViewBag.GameIDFK = new SelectList(db.tblGames, "GameID", "GameName", tblreview.GameIDFK);
            return View(tblreview);
        }
