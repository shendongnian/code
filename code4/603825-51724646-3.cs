                  public void Remove(int id)
                  {
                      var data = (from a in db.IRAS_InventoryItems
                      where a.Id == id
                      select a).FirstOrDefault();                      
                      db.IRAS_InventoryItems.Remove(data);          
                      db.SaveChanges();
                   }
