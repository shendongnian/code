    IEnumerable<Foo> Testmethod()
    {
        using(var context = new TestDBEntities())
        {
             var result = (from a in context.Table1
                           join b in context.Table2
                           on a.ID equals b.Id
                           select new Foo() { Id = b.Id , Name = b.name });
             return result.ToList();//force materializing results
        }
     }
