    [TestInitialize]
          public override void TestInitialize()
          {
             // Force model updates.
             using (var uow = UnitOfWorkFactory.Instance.Create<UnitOfWorkCore>(DefaultConnectionString))
             {
                uow.Database.Initialize(force: false);
             }
    
             // begin transaction
             this.transactionScope = new TransactionScope();
    
             this.unitOfWork = UnitOfWorkFactory.Instance.Create<UnitOfWorkCore>(DefaultConnectionString);
          }
