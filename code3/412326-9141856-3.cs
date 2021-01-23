    public class MyProvider : IProviderOut<MyElement>, IProviderIn<MyElement> {
      public IEnumerable<MyElement> Provide() {
        ...
      }
      public void Add(MyElement t) {
        ...
      }
    }
