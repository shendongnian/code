    public interface IFactory {
        ICollection<T> Create<T>(IEnumerable<T> values);
    }
    
    public class Worker { //not generic
        IFactory _factory;
    
        public Worker(IFactory factory) {
            _factory = factory;
        }
    
        public ICollection<T> DoWork<T>(IEnumerable<T> values) { //generic method
            return _factory.Create<T>(values);
        }
    }
    public static class Program {
        class ListFactory : IFactory {
            public ICollection<T> Create<T>(IEnumerable<T> values) {
                return Factory.CreateList(values);
            }
        }
    
        class SetFactory : IFactory {
            public ICollection<T> Create<T>(IEnumerable<T> values) {
                return Factory.CreateSet(values);
            }
        }
     
        public static void Main() {
            string[] values1 = new string[] { "a", "b", "c" };
            int[] values2 = new int[] { 1, 2, 2, 2 };
    
            Worker listWorker = new Worker(new ListFactory());
            Worker setWorker = new Worker(new SetFactory());
    
            ICollection<string> result1 = listWorker.DoWork(values1);
            ICollection<int> result2 = listWorker.DoWork(values2); //.Count == 4
            ICollection<int> result3 = setWorker.DoWork(values2); //.Count == 2
        }
    }
