    [CollectionDataContract( Namespace="http://mynamespace.com" )]
    public class MyCustomPartsCollection : Collection<CustomPartOfAContract>
    {
        public MyCustomPartsCollection()
        {
            // We need a default constructor or the serializer complains.
        }
    }
