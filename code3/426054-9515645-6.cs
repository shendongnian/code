    public interface IProducer { }
    public interface IProducer<T> : IProducer
    {
      IConsumable<T> Consumer { get; set; }
      void Produce();
    }
  
    public interface IConsumableProvider
    {
      void SetupProducers(params IProducer[] producers);
    }
    public class MyType : 
      IConsumable<int>,
      IConsumable<double>,
      IConsumableProvider
    {
      public void Consume(int item)
      {
        throw new NotImplementedException();
      }
      public void Consume(double item)
      {
        throw new NotImplementedException();
      }
      public void SetupProducers(params IProducer[] producers)
      {
        (producers[0] as IProducer<int>).Consumer = (this as IConsumable<int>);
        (producers[1] as IProducer<double>).Consumer = (this as IConsumable<double>);
      }
    }
