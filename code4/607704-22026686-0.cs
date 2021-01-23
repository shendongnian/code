    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Windows.Data;
    using System.Windows.Threading;
    
    namespace WpfAsyncCollection
    {
        public class AsyncObservableCollection<T> : ObservableCollection<T>
        {
            public override event NotifyCollectionChangedEventHandler CollectionChanged;
            private static object _syncLock = new object();
    
            public AsyncObservableCollection()
            {
                enableCollectionSynchronization(this, _syncLock);
            }
    
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                using (BlockReentrancy())
                {
                    var eh = CollectionChanged;
                    if (eh == null) return;
    
                    var dispatcher = (from NotifyCollectionChangedEventHandler nh in eh.GetInvocationList()
                                      let dpo = nh.Target as DispatcherObject
                                      where dpo != null
                                      select dpo.Dispatcher).FirstOrDefault();
    
                    if (dispatcher != null && dispatcher.CheckAccess() == false)
                    {
                        dispatcher.Invoke(DispatcherPriority.DataBind, (Action)(() => OnCollectionChanged(e)));
                    }
                    else
                    {
                        foreach (NotifyCollectionChangedEventHandler nh in eh.GetInvocationList())
                            nh.Invoke(this, e);
                    }
                }
            }
    
            private static void enableCollectionSynchronization(IEnumerable collection, object lockObject)
            {
                var method = typeof(BindingOperations).GetMethod("EnableCollectionSynchronization", 
                                        new Type[] { typeof(IEnumerable), typeof(object) });
                if (method != null)
                {
                    // It's .NET 4.5
                    method.Invoke(null, new object[] { collection, lockObject });
                }
            }
        }
    }
