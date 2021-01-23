     public void CleanBasket()
        {
            //double validHours = 3;
            var baskets = db.Baskets.Select(a=>a).ToList();
            foreach (var basket in baskets)
                    {
                    if ((DateTime.Now - 
                         basket.DateCreated).TotalHours 
                         > validhours)
                        db.Baskets.DeleteObject(expiredBasket)
                    }
            db.SaveChanges();
        }
