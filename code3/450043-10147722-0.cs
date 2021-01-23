    public interface IExample<T> {
        T GetAnything<T>();
    }
    public class Get : IExample<MyType> {
        public MyType GetAnything<MyType>() {
            MyType mt = new MyType();
        }
    }
    public class MyType {
      // ...
    }
