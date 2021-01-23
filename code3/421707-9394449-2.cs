    public static void Remove(IFoo foo) {
        lock (items) { // also remove any dead debris
            items.RemoveAll(x => !x.IsAlive || x.Target == foo || x.Target == null);
        }
    }
