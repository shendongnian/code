        //This actual implementation is untested and may contain small errors.
        //The helper method has been tested and *should* work.
        
        public static IMongoQuery GetMongoQuery<T>(this IQueryable<T> query)
        {
            return ((MongoQueryable<T>)query).GetMongoQuery();
        }
        var temp =    from x in DB.Foo.AsQueryable<Test>()
                      where x.SomeField > 5;
                      select (x.OtherField);
        return temp.GetMongoQuery().ToJson();
