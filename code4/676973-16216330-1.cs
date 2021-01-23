      [TestInitialize()]
      public void Initialize()
      {
         //Init DB Transaction
      }
      [TestCleanup()]
      public void Cleanup()
      {
         //Rollback DB Transaction, database returns to the initial state
      }
