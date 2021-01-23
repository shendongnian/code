    private IQueryable<Item> Items
        {
            get
            {
                var items = _db.Items;
                if (User.IsInRole("Admin"))
                {
                     return items;
                }
                return items.Where(d => d.CreatedBy == User.Identity.Name);
            }
        }
