        class MyObjectIterator: ParallelSkipTakeIterator<MyObject>
        {
            private List<int> instanceIds;
            
            public PropertyRecordMatchFileIterator(List<int> someExtraInfoNeededByQuery)
                : base(f => f.InstanceId)
            {
                this.instanceIds = someExtraInfoNeededByQuery;
            }
            protected override IQueryable<MyObject> BuildIQueryable(YourObjectContextHere db)
            {
                IQueryable<MyObject> myObjects= db.SomeCollection.Select(x => this.instanceIds.Contains(x).Include("SomethingImportant");
                return myObjects;
            }
        }
