     [HttpPost]
     public ActionResult Index(BlockModel model)
     {
        if (ModelState.IsValid)
        {
            MyBlock.BlockClass newVol = new MyBlock.BlockClass(model.Length, model.Width, model.Height);
            
            return View("MyBlockView", newVol);   // The view you want to pass the model too
        }
     }
