    public interface IJob<T, R>
        where T : IStep
        where R : IDelivery
    {
        T Step { get; set; }
        R Delivery { get; set; }
    }
