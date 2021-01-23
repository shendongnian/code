    public class MyClass : IDisposable {
        private bool _disposed = false;
        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this); // stop the GC clearing us up, 
        }
        protected virtual Dispose(bool disposing){
            if ( !_disposed ){
                if ( disposing ){
                    // someone called Dispose()
                    // dispose any other IDispose objects we have
                }
                _disposed = true;
            }
        }
    }
