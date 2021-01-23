            var itemBinding = db.ItemBinding.Where(x => x.BindingToId == id) ;
            foreach (var ib in itemBinding)
            {
                db.Item.Remove(ib.Item);
                db.ItemBinding.Remove(ib);
            }
            db.SaveChanges();
