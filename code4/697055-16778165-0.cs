         [HttpPost]
     public ActionResult ClientInformationEdit(int id, FormCollection form)
       {
            //rptLOA_GridCommands(form, id);
    
           CIHelper ch = new CIHelper();
    
    
           ch.person.LastName = form["txtClientLastName"]; 
           db.SaveChanges();
    
            return View(ch);
        }
