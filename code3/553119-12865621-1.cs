    public interface IJob<out T, out R>
        where T : IStep
        where R : IDelivery
    {
        T Step { get; }
        R Delivery { get; }
    }
