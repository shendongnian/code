    public void DeleteGallery(int id)
    {
        var entity = dataContext.Galleries
                    .Include(e => e.Articles)  // include your child object collection
                    .First(e => e.Id == id);
        dataContext.Galleries.Articles.Clear();  // this removes the reference to the parent
        dataContext.Galleries.Remove(entity);
        dataContext.SaveChanges();
    }
