    public class SomeService
    {
        private IBucketActionsHandlerFactory factory;
        private IBucketRepository repository;
        public SomeService(IBucketActionsHandlerFactory factory,
            IBucketRepository repository)
        {
            this.factory = factory;
            this.repository = repository;
        }
        public void Handle(int amountToRetrieve)
        {
            var largeBucket = this.repository.GetById(LargeBucketId);
            var smallBucket = this.repository.GetById(SmallBucketId);
            var handler = this.factory.Create(largeBucket, smallBucket,
                amountToRetrieve);
            handler.CalculateSteps();
        }
    }
