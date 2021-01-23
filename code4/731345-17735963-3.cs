    public interface IFoo
    {
        string Get();
    }
    public interface IBar : IFoo
    {
        new string Get();
    }
