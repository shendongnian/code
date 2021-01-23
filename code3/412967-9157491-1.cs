    public class MyClass : IEnumerable<Item> {
      public IEnumerator<Container<T>> GetEnumerator() {
        // here you return your items, for example by returning an enumerator:
        return someArray.GetEnumerator();
        // or by using yield return:
        for (int i = 0; i < 10; i++) {
          yield return new Item(i);
        }
      }
      // this is needed, because IEnumerable<T> inherits IEnumerable
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
        // uses the generic implementation
        return GetEnumerator();
      }
    }
