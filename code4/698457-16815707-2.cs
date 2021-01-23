    public class UnitOfWork: IDisposable  {
        // this is thread-safe in actual implementation
        private static Stack<UnitOfWork> _uowStack = new Stack<UnitOfWork>();
        public static UnitOfWork Current {get { return _uowStack.Peek(); }} 
    
        public Respository() {
            _uowStack.Push(this);
        }
    
        public void Dispose() {
            _ouwStack.Pop();
        }
        public void SaveChanges() {
            // do some db operations
        }
    }
    public class Repository {
        public void DoSomething(Entity entity) {
            // Do Some db operations         
            UnitOfWork.Current.Save();
        }
    }
