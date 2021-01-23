    public void MyMethod()
    {
        using(MyContext context = new MyContext())
        {
          var query = dbGetMyItems(context);
        }
    }
