     <div class="editor-field">
                    @Html.DropDownList("GameIDFK", String.Empty)
                    @Html.ValidationMessageFor(model => ViewBag.GameIDFK)
                </div>
        
        
        [HttpPost]
        public ActionResult Create(tblReview tblreview, FormCollection formCollection)
           {
                    if (ModelState.IsValid)
                    {
                         
                        db.tblReviews.Add(tblreview);
                        db.SaveChanges();
                       // return RedirectToAction("Index");  
                    }
                     int gameid=Convert.ToInt32(formCollection["GameIDFK"]);
                    var userGames = (from g in db.tblGames where g.UserName== User.Identity.Name && g.GameID!=gameid select g).ToList();
                    ViewBag.GameIDFK = new SelectList(userGames, "GameID", "GameName");
                    return View(new tblReview { UserName = @User.Identity.Name });
        }
