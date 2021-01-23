    // True => worked, False => timeout
    public static bool CallWithTimeout(Action method, TimeSpan timeout) {
      Exception e;
      Task worker = Task.Factory.StartNew(method)
                        .ContineueWith(t => {
                          // Ensure any exception is observed, is no-op if no exception.
                          // Using closure to help avoid this being optimised out.
                          e = t.Exception;
                        });
      return worker.Wait(timeout);
    }
