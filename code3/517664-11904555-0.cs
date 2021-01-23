    public class AsyncThreadPool<T extends IAsyncThread<K>, K> {
        private final AsyncThreadFactory<T> factory;
        public ASyncThreadPool(AsyncThreadFactory<T> factory) {
            this.factory = factory;
        }
        public void foo() {
            T t = factory.createDefault();
            t.startAsyncRequest();
        }
    }
