    public static void AssertWasCalledAndDump<T>(this T self, Action<T> action)
    {
        try
        {
            self.AssertWasCalled(action);
        }
        catch (Rhino.Mocks.Exceptions.ExpectationViolationException)
        {
            self
                .GetArgumentsForCallsMadeOn(action, options => options.IgnoreArguments())
                .PrintDump();
            throw;
        }
    }
