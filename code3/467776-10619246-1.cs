        public static void Do()
        {
            var target = new MyClass();
            var list = new List<MyClass>
            {
                new MyClass { A = 1M, B = 2M, C = 3M },
                new MyClass { A = 10M, B = 20M, C = 30M },
                new MyClass { A = 100M, B = 200M, C = 300M }
            };
            // calculate 'min' for all decimal properties
            var helper = new AggregateHelper<MyClass, Decimal>();
            foreach (var property in helper.Properties)
            {
                var propertyHelper = helper[property];
                propertyHelper.Setter(target, list.Min(propertyHelper.Selector));
            }
        }
