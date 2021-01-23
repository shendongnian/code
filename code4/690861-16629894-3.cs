    [TestInitialize]
          public override void TestInitialize()
          {
             // Force model updates.
             // I CHANGED TO THIS:
             Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
    
             using (var uow = UnitOfWorkFactory.Instance.Create<UnitOfWorkCore>(DefaultConnectionString))
             {
                uow.Database.Initialize(force: false);
             }
    
             // begin transaction
             this.transactionScope = new TransactionScope();
    
             this.unitOfWork = UnitOfWorkFactory.Instance.Create<UnitOfWorkCore>(DefaultConnectionString);
          }
