          if (ModelState.IsValid && f != null)
            {
                myEntities.Friend.Attach(f);
		 var upd = (from c in myEntities.Friend
                           where c.Id == f.Id
                           select c).FirstOrDefault();
		upd.Data1=f.Data1;
		...
		....
                myEntities.ObjectStateManager.ChangeObjectState(f, EntityState.Modified);
                myEntities.SaveChanges();
            }
