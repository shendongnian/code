    public ActionResult AddToCart(YourCartViewmodel cartViewmodel)
    {
         if (ModelState.IsValid)
         {
             // do the standard/common db stuff here
             if(Request.IsAjaxRequest())
             {
                 return PartialView("myPartialView");
             }
             else
             {
                 return View("standardView");
             }
         }
         /* always return full 'standard' postback if model error */
         return View(cartViewmodel);   
    }
