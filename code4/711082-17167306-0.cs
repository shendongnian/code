    interface IMyDomainRepository
    {
        IEnumerable<EntitiyData> GetData(Conditions conditions);
        void Create(IEnumerable<EntityData> entities);
    }
