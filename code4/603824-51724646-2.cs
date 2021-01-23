             public void Remove(int id)
             {
                var data = db.IRAS_InventoryItems.Find(id);
                data.IsActive = false;
                db.IRAS_InventoryItems.Remove(data);       
                db.SaveChanges();
             }
