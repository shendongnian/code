    public class SomeOtherBusinessObject
    {
        private IDataAccessFactory _DataAccessFactory;
        
        public SomeOtherBusinessObject(
            IDataAccessFactory dataAccessFactory,
            INotificationService notifcationService,
            IErrorHandler errorHandler)
        {
            this._DataAccessFactory = dataAccessFactory;
        }
        
        public void DoSomething()
        {
            for (int i = 0; i < 10; i++)
            {
                using (var dao = this._DataAccessFactory.Create<MyDao>())
                {
                    // work with dao
                    // Console.WriteLine(
                    //     "Working with dao: " + dao.GetHashCode().ToString());
                }
            }
        }
    }
