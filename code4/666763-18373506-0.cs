    public OrderPrice DoAction()
    {
        Task<OrderPrice> task = Task<OrderPrice>.Factory.StartNew(NamedPipeClient);
        task.Start();
        if (domain == null)
            domain = AppDomain.CreateDomain(DOMAINNAME);
        domain.DoCallBack(AppDomainCallback);
        return task.Result; 
    }
