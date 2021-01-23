    public void GetFooAsyncCallback(Func<Foo> getFoo)
    {
        try
        {
            Foo foo = getFoo();
            //work with foo
        }
        catch(Exception ex)
        {
            //handle exception
        }
    }
