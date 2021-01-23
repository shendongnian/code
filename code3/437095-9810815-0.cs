        public void Test()
        {
            List<SomeData> data = new List<SomeData>();
            data.Add(new SomeData("Mark", "Ledgewood Drive"));
            data.Add(new SomeData("Tim", "Sumpter Drive"));
            data.Add(new SomeData("Sean", "Leroy Drive"));
            data.Add(new SomeData("Bob", "Wilmington Road"));
            data.Add(new SomeData("Sean", "Sunset Blvd"));
            List<SomeData> result = data.Where(BuildExpression("Name", "Mark")).ToList();
            List<SomeData> result2 = data.Where(BuildExpression("Address", "Wilmington Road")).ToList();
        }
        private Func<SomeData, bool> BuildExpression(string propertyName, string value)
        {
            ParameterExpression pe = Expression.Parameter(typeof(SomeData), "someData");
            Expression left = Expression.Property(pe, propertyName);
            Expression right = Expression.Constant(value);
            BinaryExpression binary = Expression.Equal(left, right);
            Expression<Func<SomeData, bool>> lambda = Expression.Lambda<Func<SomeData, bool>>(binary, pe);
            return lambda.Compile();
        }
