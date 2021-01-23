               public void IsActiveItem(int id)
               {
                var data = (from a in db.IRAS_InventoryItems
                where a.Id == id
                select a).FirstOrDefault();
                data.IsActive = false;
                db.Entry(data).State = EntityState.Modified;           
                db.SaveChanges();
               }
