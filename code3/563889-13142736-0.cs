    var object locker = new object();
    var timer = new System.Threading.Timer(_ => {
      bool entered = Monitor.TryEnter(locker);
      try {
        if (entered) {
          method(null);
        }
      } finally {
         if (entered) {
           Monitor.Exit(locker);
         }
      }
    },  null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
