        public virtual void Save(TModel t)
        {
            db.SystemUserLogs.Attach(t);
            //db.Entry(t).State = EntityState.Modified; //<--- For whole fields modifier
            db.Entry(t).Property(x => x.entitySetName).IsModified = true; //<--- For one field modifier
            db.SaveChanges();
        }
