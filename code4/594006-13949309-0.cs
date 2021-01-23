      public virtual T AttachAsModified(T item) {
            item = _dbSet.Attach(item);
            db.Entry(item).State = System.Data.EntityState.Modified
            return item;
        }
