        [HttpPost]
        public ActionResult A(Model m, string s)
        {
            if (ModelState.IsValid) 
            {
                if (m.l == null || m.k == null)
                {
                    //Do something.                    
                }
                else
                {
                    TempData["tempModel"]=m; //cannot pass a model in a redirect method. so store it in a tempdata object.
                    return RedirectToAction("B"); // redirect to action method B
                }
            }
            return View(m);    
        }   
        
        public ActionResult B()
        {
            Model model= new Model();
            if(TempData["tempModel"]!=null)
                model=(Model)TempData["tempModel"];
            return View(model);
        }
