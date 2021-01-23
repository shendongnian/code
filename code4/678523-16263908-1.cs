    public ManageWorkOrdersAppServ(Context dbContext)
        : base(new WorkOrderHeaderRepository(dbContext )) 
    {
        _workOrderHeaderRepository = new WorkOrderHeaderRepository(_dbContext);
        _workOrderDetailRepository = new WorkOrderDetailRepository(_dbContext);
    }
