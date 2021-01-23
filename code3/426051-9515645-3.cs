    var method = GetType().GetMethod("Process");
    var genericType = interfaceType.GetGenericArguments().First();
    var invocable = method.MakeGenericMethod(genericType);
    invocable.Invoke(this, new object[] { producer, consumer });
    public void Process<T>(IProducer<T> producer, IConsumable<T> consumer)
    {
      producer.Consumer = consumer;
    }
