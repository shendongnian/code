    interface IGenericRepository<out T>
    {
        T Get(int id); // this is fine, but:
        void Save(T value); // does not compile; this is not covariantly valid
    }
