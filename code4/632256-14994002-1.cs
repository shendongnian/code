    //Serve the view when the URL is requested
        public ActionResult ViewAllItems()
        { 
            return View();
        }
    //Handle the posted form from the ViewAllItems page
     [HttpPost]
        public ActionResult ViewAllItems(int selectedItemId)
        { 
            RedirectToAction("ViewItemDetail", new { id = selectedItemId });
        }
     
        public ViewResult ViewItemDetail(int id)
        { 
           var item = repo.GetItem(id);
           return View(item);
        }
