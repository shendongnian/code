    public ActionResult JsonAddToCart(Viewmodel vm)
    {
         if (ModelState.IsValid)
         {
             DoStuff(vm);
             return View("ViewForJS");
         }
         /* error */
         return View(vm);     
    }
