    private static InventoryMgmtContext _dbContext = new InventoryMgmtContext();
    public ManageWorkOrdersAppServ()
        : base(new WorkOrderHeaderRepository(_dbContext )) 
    {
        _workOrderHeaderRepository = new WorkOrderHeaderRepository(_dbContext);
        _workOrderDetailRepository = new WorkOrderDetailRepository(_dbContext);
    }
