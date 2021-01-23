    public static async Task<SomeType> Foo()
    {
        try
        {
            var firstResult = await Process1();
            var secondResult = await Process2();
            var thirdResult = await Process3();
            var finalResult = await SuccessCondition();
            return finalResult;
        }
        catch (SomeExceptionType ex)
        {
            HandleException(ex);
        }
    }
