    public void Execute(Action<DbContext> action)
    {
        try
        {
           using(var context = new MyContext())
           {
               action(context);
               context.SaveChanges();
           }
        }
        catch(ConcurrencyException exception)
        {
        }
        catch(ValidationException exception)
        {
        }
        catch(SqlException exception)
        {
        }
    }
