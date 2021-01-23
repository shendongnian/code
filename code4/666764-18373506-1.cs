    public OrderPrice DoAction()
    {
        Task<OrderPrice> task = Task<OrderPrice>.Factory.StartNew(NamedPipeClient);
        if (domain == null)
            domain = AppDomain.CreateDomain(DOMAINNAME);
        domain.DoCallBack(AppDomainCallback);
        return task.Result; 
    }
