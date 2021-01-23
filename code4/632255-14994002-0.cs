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
