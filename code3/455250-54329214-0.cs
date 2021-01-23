public class MyProxyCollection : IList<MyItem> {
  MyProxyCollection(... /* reference to actual collection */ ...) {...}
  // Implement IList here
}
public class MyModel {
  MyProxyCollection _proxy;
  public MyModel() {
    _proxy = new MyProxyCollection (... /* reference to actual collection */ ...);
  }
  
  // Here we make sure the getter and setter always return a reference to the same
  // collection object. This ensures that we add items to the correct collection on
  // deserialization.
  public MyProxyCollection Items {get; set;}
}
This ensures that getting/setting the collection object works as expected.
