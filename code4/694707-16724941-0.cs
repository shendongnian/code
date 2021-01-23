    [HttpGet]
            public ActionResult Application(Genre genre)
            {
                var vv = new FlowViewModel();
              
                vv.GenreItems = new SelectList(db.Genres.ToList(), "ID_G", "ID_G");
                
                
               
                return View(vv);
    
            }
