    public interface IDataConsumerClass
    {
        bool LoadIt(Func<IEnumerable<string>> load);
        bool ExecuteIt(Action execute);
    }
    //...
    dataConsumer.Expect(fc => fc.ExecuteIt(Arg<Action>.Matches(x => ActionWrapper(x)))).Return(true);
    //...
    private bool ActionWrapper(Action action)
    {
        action();
        return true;
    }
