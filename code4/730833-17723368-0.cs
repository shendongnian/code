    var itemToRemove = Context.Employ.SingleOrDefault(x => x.id == 1); //returns a single item.
    if (itemToRemove != null) {
        Context.Employ.Remove(itemToRemove);
        Context.SaveChanges();
    }
