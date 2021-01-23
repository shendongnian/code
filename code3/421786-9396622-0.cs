    try
            {
                using (var db = new AssociateDBEntities())
                {
                    db.Entry(associate).State = System.Data.EntityState.Deleted;
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
