    interface IGetById
    {
        T GetById<T>(object id);
    }
    interface IGetAll
    {
        IEnumerable<T> GetAll<T>();
    }
    interface ISave
    {
        void Save<T>(T item) where T : IHasId; //you can go with Save<T>(object id, T item) if you want pure pure POCOs
    }
    interface IDelete
    {
        void Delete<T>(object id);
    }
    interface IHasId
    {
        object Id { get; set; }
    }
