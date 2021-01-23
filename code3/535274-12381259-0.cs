    public class BucketDispenser
    {
        public TBucket Dispense<TBucket>(string typeName) where TBucket : Bucket
        {
            Bucket widget= new Widget();
            // or
            Bucket widget = new OtherWidget();
            return (TBucket)(object)widget;
        }
    }
