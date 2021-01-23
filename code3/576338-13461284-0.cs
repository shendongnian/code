        public FooGenericSample(Func<IFoo, TBar> getter) {
            _getter = getter;
        }
        public IQueryable<TBar> Data {
            get { 
                return _getter(_foo);
            }
        }
    }
    // ...
    var foo1Sample = new FooGenericSample(f => f.Bar1);
    // foo2Sample etc.
