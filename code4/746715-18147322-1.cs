    interface IGetAllSaveAll<T>
    {
        IEnumerable<T> GetAll();
        void SaveAll(IEnumerable<T> obj);
    }
