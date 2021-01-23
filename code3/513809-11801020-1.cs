    public Bar SomeMethodThatCanThrowException()
    {
        Bar b = new Bar();
        return ExecOrDefault(() => b.Execute(), Bar.ErrorCode, ex => new Bar { ErrorMessage = ex.Message, ErrorCode = Bar.ErrorCode });
    }
