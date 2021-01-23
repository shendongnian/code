       LOJAEntities loja = new LOJAEntities();
       #region IBaseCRUD<T> Members
       public void Add(T pEntity)
        {
            loja.AddObject(pEntity.GetType().Name, pEntity);
        }
        public void Delete(T pEntity)
        {
            loja.DeleteObject(pEntity);
        }
        public void Attach(T pEntity)
        {
            loja.AttachTo(pEntity.GetType().Name, pEntity);
        }
        public void Detach(T pEntity)
        {
            loja.Detach(pEntity);
        }
        public void Update(T pEntity)
        {
            loja.ApplyCurrentValues<T>(pEntity.GetType().Name, pEntity);
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            try
            {
                return loja.CreateObjectSet<T>().Where(where);
            }
            catch { return null; }
            
        }
        public IQueryable<T> GetAll()
        {
            return loja.CreateObjectSet<T>();
        }
        public void SaveChanges()
        {
            loja.SaveChanges();
        }
       #endregion
