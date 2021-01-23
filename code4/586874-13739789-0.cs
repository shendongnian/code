    public class ProducerConsumer<T>:IDisposable 
        {
            private  int _consumerThreads;
            private readonly Queue<T> _queue = new Queue<T>();
            private readonly object _queueLocker = new object();
            private readonly AutoResetEvent _queueWaitHandle = new AutoResetEvent(false);
            private readonly Action<T> _consumerAction;
            private readonly log4net.ILog _log4NetLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            private bool _isProcessing = true;
    
            public ProducerConsumer(Action<T> consumerAction,int consumerThreads,bool isStarted)
            {
                _consumerThreads = consumerThreads;
    
                if (consumerAction == null)
                {
                    throw new ArgumentNullException("consumerAction");
                }
                _consumerAction = consumerAction;
                if (isStarted)
                    Start();
                //just in case the config item is missing or is set to 0.  We don't want to have the queue build up
            }
    
            public ProducerConsumer(Action<T> consumerAction, int consumerThreads):this(consumerAction,consumerThreads,true)
            {
    
    
            }
            public void Dispose()
            {
                _isProcessing = false;
                lock(_queueLocker)
                {
                    _queue.Clear();
                }
            }
            public void Start()
            {
                if (_consumerThreads == 0)
                    _consumerThreads = 2;
    
                for (var loop = 0; loop < _consumerThreads; loop++)
                    ThreadPool.QueueUserWorkItem(ConsumeItems);
            }
    
            public void Enqueue(T item)
            {
                lock (_queueLocker)
                {
                    _queue.Enqueue(item);
                    // After enqueuing the item, signal the consumer thread.            
                    _queueWaitHandle.Set();
                }
            }
    
            private void ConsumeItems(object state)
            {
                while (_isProcessing)
                {
                    try
                    {
                        var nextItem = default(T);
                        bool doesItemExist;
                        lock (_queueLocker)
                        {
                            int queueCount = _queue.Count;
                            doesItemExist = queueCount > 0;
                            if (doesItemExist)
                            {
                                nextItem = _queue.Dequeue();
                            }
                            if (queueCount > 0 && queueCount % 50 == 0)
                                _log4NetLogger.Warn(String.Format("Queue is/has been growing.  Queue size now:{0}",
                                                                  queueCount));
                        }
                        if (doesItemExist)
                        {
                            _consumerAction(nextItem);
                        }
                        else
                        {
                            _queueWaitHandle.WaitOne();
                        }
                    }
                    catch (Exception ex)
                    {
    
                        _log4NetLogger.Error(ex);
                    }
    
                }
            }
        }
