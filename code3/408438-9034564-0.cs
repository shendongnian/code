    public class CallbackQueueItem<T> {
        public Func<T> Func { get; set; }
        public Action<object> Callback { get; set; }
    }
    public class CallbackQueue<T> {
        private readonly BlockingCollection<CallbackQueueItem<T>> _items;
        public CallbackQueue(int upperLimit) {
            _items = new BlockingCollection<CallbackQueueItem<T>>(upperLimit);            
        }
        private BlockingCollection<CallbackQueueItem<T>> Items {
            get { return _items; }
        }
        public void Start()
        {
            Task.Factory.StartNew(() => {
                while(!Items.IsCompleted) {
                    CallbackQueueItem<T> item;
                    try {
                        item = Items.Take();
                    }
                    catch(InvalidOperationException) {
                        break;
                    }
                    if(item != null) {
                        var result = item.Func();
                        Task.Factory.StartNew(item.Callback,result);
                    }
                }
            });
        }
        public void Stop() {
            Items.CompleteAdding();
        }
        public void Push(CallbackQueueItem<T> item) {
            Items.Add(item);
        }
    }
