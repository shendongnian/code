        public void Detele(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }
