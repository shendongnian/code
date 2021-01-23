    [HttpPost]
    public ActionResult ModifyContract(ModContract mod)
    {
        // submit modified contract
        if (ModelState.IsValid)
        {
            OutlookMediaEntities1 db = new OutlookMediaEntities1();
    
            var updatedMod = db.ModContract.Single(m=>m.contract_id == mod.contract_id);
            TryUpdateModel<ModContract>(updatedMod);
            // save changes
            db.SaveChanges();
    
            return RedirectToAction("ContractDetails", "Contract", new { id = (int) ViewData["contractid"] });
        }
        else
        {
            ModelState.AddModelError("", "Missing necessary information");
            return View();
        }
    }
