    var model = new Model {
        foo = new FooClass {
            bar = new List<BarClass> {
                new BarClass { prop = "value1" },
                new BarClass { prop = "value2" }
            }
        }
    };
    var queryString = new ViewDataDictionary<Model>(model).ModelMetadata.ToQueryString();
    
