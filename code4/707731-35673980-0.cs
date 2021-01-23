    using (MyDataContext context = new MyDataContext())
    {
        // this is just some random query, that has not been listed - ToList()
        // thus query execution is defered. listFromDB = IQueryable<>
        var listFromDB = context.SomeTable.Where(st => st.Something == true);
        System.Threading.Tasks.Task.Factory.StartNew(() => 
        {
            var list1 = listFromDB.Take(5000).ToList(); // runs the SQL query
            // call some function on list1
        });
        System.Threading.Tasks.Task.Factory.StartNew(() => 
        {
            var list2 = listFromDB.Take(5000).ToList(); // runs the SQL query
            // call some function on list2
        });
    }
