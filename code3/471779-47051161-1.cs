    interface IRepository<T> where T: Identity
        {
            T GetById(int id);
            ICollection<T> GetAll();
            ICollection<T> GetAll(string where);
            void Update(T entity);
            void Insert(T entity);
            bool Delete(T entity);
            bool Delete(ICollection<T> entityes);
        }
