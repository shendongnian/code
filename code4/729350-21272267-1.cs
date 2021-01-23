    class MyDbContext : DbContext 
    {
        private static Expression<Func<MyClass, int>> myExpression1 = x => /* something complicated ... */;
        private static Expression<Func<Item, int>> myExpression2 = x => /* something else complicated ... */;
    
        public object GetAllData()
        {
            Expression<Func<MyClass, int>> myLocalExpression1 = myExpression1;
            Expression<Func<MyClass, int>> myLocalExpression2 = myExpression2;
            return (
                from o in MyClassDbSet.AsExpandable() 
                select new 
                {
                    data1 = myLocalExpression1.Invoke(o),
                    data2 = o.Items.Select(item => myLocalExpression1.Invoke(item)) 
                }
            );
        }
    }
