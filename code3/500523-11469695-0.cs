    const double bucketSize = 15.0;
    var totalItems = (double)linjer;
    var optimumBuckets = Math.Ceiling(totalItems / bucketSize);
    var itemsPerBucket = (int)Math.Ceiling(totalItems / optimumBuckets);
    var buckets = new int[(int)optimumBuckets];
    var itemsLeft = (int)totalItems
    for (var i = 0; i < buckets.length; i++)
    {
        if (itemsLeft < itemsPerBucket)
        {
            buckets[i] = itemsLeft;
        }
        else
        {
            buckets[i] = itemsPerBucket;
        }
        itemsLeft -= itemsPerBucket;
    }
