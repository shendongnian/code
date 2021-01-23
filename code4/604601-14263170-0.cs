    public DomainObject : AggregateRootBase //Implements IAggregateRoot
    {
        public void DoSomething() { }
    }
    public IDomainObjectRepository : IRepository<DomainObject>, IEnumerable
    {
        DomainObject this[object id] { get; set; }
        void Add(DomainObject do);
        void Remove(DomainObject do);
        int IndexOf(DomainObject do);
        object IDof(DomainObject do);
        IEnumerator<DomainObject> GetEnumerator();
    }
