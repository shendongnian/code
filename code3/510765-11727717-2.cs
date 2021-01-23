    public class BucketActionsHandlerFactory
        : IBucketActionsHandlerFactory
    {
        private Container container;
        public class BucketActionsHandlerFactory(
            Container container)
        {
            this.container = container;
        }
        public IBucketActionsHandler Create(
            Bucket largeBucket, Bucket smallBucket,
            int amountToRetrieve)
        {
            return new BucketActionsHandler(
                largeBucket, smallBucket, amountToRetrieve,
                this.container.Get<IActionLogger>());
        }
    }
