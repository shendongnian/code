    [HttpGet]
    public ActionResult Update(){
         //[...] retrive your record object
         return View(objRecord);
    }
    [HttpPost]
    public ActionResult Update(string id, string productid, int qty, decimal unitrate)
    {
          if (ModelState.IsValid){
               int _records = UpdatePrice(id,productid,qty,unitrate);
               if (_records > 0){                    {
                  return RedirectToAction("Index1", "Shopping");
               }else{                   
                    ModelState.AddModelError("","Can Not Update");
               }
          }
          return View("Index1");
     }
