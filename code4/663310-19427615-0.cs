       protected List<T> ListAll<T>() where T : class
        {
            using (MyDbContext db = new MyDbContext ()) 
            {
                return db.Set(typeof(T)).Cast<T>().AsNoTracking<T>().ToList();
            }
            
        }
        protected T ListAllById<T>(int id) where T : class
        {
            using (MyDbContext db = new MyDbContext ()) 
            {
                return db.Set(typeof(T)).Cast<T>().Find(id);
            }
        }
        protected void InsertObj(Object obj)
        {
            using (MyDbContext db = new MyDbContext()) 
            {
                db.Set(obj.GetType()).Add(obj);
                db.SaveChanges();
            }
        }
        protected void UpdateObj(Object obj)
        {    
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.Set(obj.GetType()).Attach(obj);
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(" " + ex.Message);
            }            
        }
        protected void DeleteObj(Object obj)
        {
            using (MyDbContext db = new MyDbContext ())
            {
                db.Set(obj.GetType()).Attach(obj);
                db.Entry(obj).State = EntityState.Deleted;
                db.SaveChanges();
            }
            
        }
