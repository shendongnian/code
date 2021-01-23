    // Data Repository class
    public static class MyDataRepositoryMethods
    {
        
        static MyDataRepositoryMethods()
        {
            BsonClassMap.RegisterClassMap<MyBaseClassOfStuff>(x =>
            {
                x.AutoMap();
                x.SetIsRootClass(true);
            });
        }
        /// <summary>
        /// Returns a queryable data sample collection
        /// </summary>
        /// <typeparam name="TMyBaseClassOfStuff"></typeparam>
        /// <returns></returns>
        public static IQueryable<TMyBaseClassOfStuff> OpenQuery<TMyBaseClassOfStuff>() where TMyBaseClassOfStuff: MyBaseClassOfStuff
        {
            using (var storage = new MongoDataStorageStuff())
            {
                // _t discriminator will reflect the final class, not the base class (unless you pass generic type info of the base class
                var dataItems = storage.GetCollection<TMyBaseClassOfStuff>("abcdef").OfType<TMyBaseClassOfStuff>(); 
                return dataItems ;
            }
        }
    }
