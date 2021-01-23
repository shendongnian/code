    class Operation {
      class Helper : IDisposable {
        internal Operation Operation;
        public void Dispose() {
          Operation.EndOperation();
        }
      }
      public IDisposable BeginOperation() {
        ...
        return new Helper() { Operation = this };
      }
      private void EndOperation() {
        ...
      }
    }
