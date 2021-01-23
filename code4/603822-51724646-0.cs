            public void IsActiveItem(int id)
             {
                var data = db.IRAS_InventoryItems.Find(id);
                data.IsActive = false;
                db.Entry(data).State = EntityState.Modified;           
                db.SaveChanges();
             }
