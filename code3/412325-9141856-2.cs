    public interface IProviderOut<out T> where T : IElement {
      IEnumerable<T> Provide();
    }
    public interface IProviderIn<in T> where T : IElement {
      void Add(T t);
    }
