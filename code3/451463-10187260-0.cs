    public void Delete(int id)
    {
        var entity = dbset
                    .Include(e => e.Articles)  // include your child object collection
                    .First(e => e.Id == id);
        entity.Articles.Clear();  // this removes the reference to the parent
        dbset.Remove(entity);
        dataContext.SaveChanges();
    }
