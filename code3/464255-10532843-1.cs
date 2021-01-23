        public static void RedirectToNewDeal(String key, Object item, CacheItemRemovedReason reason) 
        {
            DatabaseEntitiesDB db = DatabaseEntitiesDB.GetInstance();
            if(reason.ToString() == "Expired")
            {
                var QueueToDisable = db.FirstOrDefault<ProductQueue>("WHERE Id = @0", key);
                QueueToDisable.Active = false;
                QueueToDisable.Update();
            }
        }
