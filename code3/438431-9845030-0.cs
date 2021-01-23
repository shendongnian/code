        [HttpPost]
        [AuthRole(Role = "Administrator")]  //Created Validataion so inaccessible from outside
        [ValidateInput(false)]      
        public ActionResult Update(Data data)       
        {       
            if (ModelState.IsValid)       
            {       
                data.ID = 1; //EF need to know which row to update in the database.       
                db.Entry(data).State = EntityState.Modified;       
                db.SaveChanges();       
                return RedirectToAction("Index", "Home");       
            }       
            return View(data);       
        }    
