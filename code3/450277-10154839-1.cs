        [HttpPost]
        public ActionResult Create(tblGame tblgame, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  var mygame = db.tblGames.Where(x=>x.Name == tblgame.Name).SingleOrDefault();
                  if (mygame !=null)
                  {
                    //proceed with saving and other stuff
                  
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
                return View("Upload_Image_Failed");
            }
            //if arrive here the model is returned back to the view with the errors added
            return View(tblgame);
        }
