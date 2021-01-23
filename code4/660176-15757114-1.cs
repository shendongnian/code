       [HttpGet]
        public ActionResult Admin()
        {
            var aux=db.UserMessages.ToList();
    
            return View(aux);         
    
        }
    
        [HttpPost]
        public ActionResult Admin(int id)
        {
            var aux = db.UserMessages.ToList();
    
            return View(aux);
    
        }
