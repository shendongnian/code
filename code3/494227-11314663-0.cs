    public IQueryable<myItem> MyQuery(MyContext context)
    {
       
            return (from myItem in context.MyItems
                    select ...);
    }
    public void MyMethod()
    {
        using(MyContext context = new MyContext())
        {
          var query = MyQuery(context);
        }
    }
