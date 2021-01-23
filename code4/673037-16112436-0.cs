    interface IFutureValue {
        object Result { get; }
    }
    interface IFutureValue<T> : IFutureValue {
        new T Result { get; }
    }
