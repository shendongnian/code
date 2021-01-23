        public List<TOut> GetEntitiesLinq<TIn,TOut>(Expression<Func<IQueryable<TIn>,IQueryable<TOut>>> myFunc)
        {
            var t = (myFunc.Compile())(_session.Query<TIn>()) ;
            return t.ToList();
        }
