        [HttpPost]
        public ActionResult Create(tblGame tblgame, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  var mygame = db.tblGames.Where(x => x.GameName == tblgame.GameName).SingleOrDefault();
                  if (mygame != null)
                  {
                    if (image1 != null)
                    {
                      string image = image1.FileName;
                      tblgame.Image = image;
                      var image1Path = Path.Combine(Server.MapPath("~/Content/UploadImages"), image);
                      image1.SaveAs(image1Path);
                    }
                    if (image2 != null)
                    {
                      string Image2 = image2.FileName;
                      tblgame.Image2 = Image2;
                      var image2Path = Path.Combine(Server.MapPath("~/Content/UploadImages"), Image2);
                      image2.SaveAs(image2Path);
                    }
                    db.tblGames.Add(tblgame);
                    db.SaveChanges();
                    //All ok, we redirect to index or to Edit method. (PRG pattern)
                    return RedirectToAction("Index");
                  }
                  else
                  {
                    //otherwise we add a generic error to the model state
                    ModelState.AddModelError("", "A game review already exists");
                  }
                }
            }
            catch
            {
              //return View("Upload_Image_Failed");
              ModelState.AddModelError("", "The upload of the images as failed");
            }
            //if we arrive here, the model is returned back to the view with the errors added
            ViewBag.ConsoleNameIDFK = new SelectList(db.tblConsoles, "ConsoleName", "ConsoleName", tblgame.ConsoleNameIDFK);
            return View(tblgame);
        }
