    void SomeMethodInOuterScope()
    {
        var context = new DataEntities();
        
        var test = new Test(context);
        
        try
        {
            test.InsertRecord(new Person());
            ...............
        }
        catch(Exception ex)
        {
            ....
        }
        finally
        {
            context.Dispose();
        }
    }
