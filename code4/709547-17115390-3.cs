    public static async Task Foo()
    {
        try
        {
            await Task.Run(Process1())
            await Task.Run(Process2())
            await Task.Run(Process3())
            SuccessCondition();
        }
        catch (SomeExceptionType ex)
        {
            HandleException(ex);
        }
    }
