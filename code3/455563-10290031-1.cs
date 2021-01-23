     public void CleanBasket()
        {
            var cutoff = DateTime.Now.Subtract(new TimeSpan(3, 0, 0));
            var baskets = db.Baskets.Where(a=>a.DateCreated<cutoff);
            db.DeleteObjects(baskets);  // You can combine this with the last line
            db.SaveChanges();
        }
