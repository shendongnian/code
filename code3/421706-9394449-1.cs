    static class Whatever {
        private static readonly List<WeakReference> items=new List<WeakReference>();
        public static void Add(IFoo foo) {
            if(foo != null) {
                var newRef = new WeakReference(foo);
                lock(items) { items.Add(newRef); }
            }
        }
        public static void DoIt(some args) {
            lock(items) {
               foreach(var item in items) {
                  IFoo foo = item.IsAlive ? item.Target as IFoo : null;
                  if(foo != null) foo.Bar(some args);
               }
            }
        }
    }
