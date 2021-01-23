    public static class MyStack
    {
      // (Part A) Provide strongly-typed access to the current stack
      private static readonly string slotName = Guid.NewGuid().ToString("N");
      private static ImmutableStack<string> CurrentStack
      {
        get
        {
          var ret = CallContext.LogicalGetData(name) as ImmutableStack<string>;
          return ret ?? ImmutableStack.Create<string>();
        }
        set { CallContext.LogicalSetData(name, value); }
      }
      // (Part B) Provide an API appropriate for pushing and popping the stack
      public static IDisposable Push([CallerMemberName] string context = "")
      {
        CurrentStack = CurrentStack.Push(context);
        return new PopWhenDisposed();
      }
      private static void Pop() { CurrentContext = CurrentContext.Pop(); }
      private sealed class PopWhenDisposed : IDisposable
      {
        private bool disposed;
        public void Dispose()
        {
          if (disposed) return;
          Pop();
          disposed = true;
        }
      }
      // (Part C) Provide an API to read the current stack.
      public static string CurrentStackString
      {
        get { return string.Join(" ", CurrentStack.Reverse()); }
      }
    }
