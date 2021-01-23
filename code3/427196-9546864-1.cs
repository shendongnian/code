    public static async Task<ReturnResultClass> GetBasicResponseAsync()
    {
        var r = await SomeClass.StartAsyncOp().ConfigureAwait(false);
        return await OtherClass.ProcessAsync(r).ConfigureAwait(false);
    }
