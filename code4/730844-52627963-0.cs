       public ActionResult Delete(int? id)
        {
            using (var db = new RegistrationEntities())
            {
                Models.RegisterTable Obj = new Models.RegisterTable();
                Registration.DAL.RegisterDbTable personalDetail = db.RegisterDbTable.Find(id);
                if (personalDetail == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    Obj.UserID = personalDetail.UserID;
                    Obj.FirstName = personalDetail.FName;
                    Obj.LastName = personalDetail.LName;
                    Obj.City = personalDetail.City;
                }
                return View(Obj);
            }
        }
        
        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int? id)
        {
            using (var db = new RegistrationEntities())
            {
                Registration.DAL.RegisterDbTable personalDetail = db.RegisterDbTable.Find(id);
                db.RegisterDbTable.Remove(personalDetail);
                db.SaveChanges();
                return RedirectToAction("where u want it to redirect");
            }
        }
