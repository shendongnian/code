    interface IUnitOfWorkFactory
    {
         IUnitOfWork Create();
    }
    interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback(); // should get called by Dispose if Commit was never called.
    }
