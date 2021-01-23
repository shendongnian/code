    private IUnitOfWorkFactory factory;
    public MyController(IUnitOfWorkFactory factory)
    {
	    this.factory = factory;
    }
	
	public ActionResult MyAction()
	{
	    using (var uow = factory.CreateUnitOfWork())
		{
		    // ...
		}
	}
