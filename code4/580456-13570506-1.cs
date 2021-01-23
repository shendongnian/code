    class Email : IDisposable {
        
        public void Dispose() {
            // The 'Dispose' method should clean up any unmanaged resources
            // that your class uses.
        }
        ~Email() {
            // You should also clean up unmanaged resources here, in the finalizer,
            // in case users of your library don't call 'Dispose'.
        }
    }
    void Main() {
        // The 'using' block can be used with instances of any class that implements
        // 'IDisposable'.
    	using (var email = new Email()) {
    	
    	}
    }
