    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using FS.Mes.Client.Mvvm.MvvmTools.MvvmLight;
    
    namespace FS.Mes.Client.Mvvm.MvvmTools
    {
        /// <summary>
        /// Our implementation of ObservableCollection. This fixes one significant limitation in the .NET Framework implementation. When items
        /// are added or removed from an observable collection, the OnCollectionChanged event is fired for each item. Depending on how the collection
        /// is bound, this can cause significant performance issues. This implementation gets around this by suppressing the notification until all
        /// items are added or removed. This implementation is also thread safe. Operations against this collection are always done on the thread that
        /// owns the collection.
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        public class FsObservableCollection<T> : ObservableCollection<T>
        {
            #region [Constructor]
            /// <summary>
            /// Constructor
            /// </summary>
            public FsObservableCollection()
            {
                DispatcherHelper.Initialize();
            }
            #endregion
    
            #region [Public Properties]
            /// <summary>
            /// Gets or sets a property that determines if we are delaying notifications on updates.
            /// </summary>
            public bool DelayOnCollectionChangedNotification { get; set; }
            #endregion
    
            /// <summary>
            /// Add a range of IEnumerable items to the observable collection and optionally delay notification until the operation is complete.
            /// </summary>
            /// <param name="items"></param>
            /// <param name="delayCollectionChangedNotification">Value indicating whether delay notification will be turned on/off</param>
            public void AddRange(IEnumerable<T> items, bool delayCollectionChangedNotification = true)
            {
                if (items == null)
                    throw new ArgumentNullException("items");
    
                DoDispatchedAction(() =>
                {
                    DelayOnCollectionChangedNotification = delayCollectionChangedNotification;
    
                    // Do we have any items to add?
                    if (items.Any())
                    {
                        try
                        {
                            foreach (var item in items)
                                this.Add(item);
                        }
                        finally
                        {
                            // We're done. Turn delay notification off and call the OnCollectionChanged() method and tell it we had a 'dramatic' change
                            // in the collection.
                            DelayOnCollectionChangedNotification = false;
                            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        }
                    }
                });
            }
    
            /// <summary>
            /// Clear the items in the ObservableCollection and optionally delay notification until the operation is complete.
            /// </summary>
            public void ClearItems(bool delayCollectionChangedNotification = true)
            {
                // Do we have anything to remove?
                if (!this.Any())
                    return;
    
                DoDispatchedAction(() =>
                {
                    try
                    {
                        DelayOnCollectionChangedNotification = delayCollectionChangedNotification;
    
                        this.Clear();
                    }
                    finally
                    {
                        // We're done. Turn delay notification off and call the OnCollectionChanged() method and tell it we had a 'dramatic' change
                        // in the collection.
                        DelayOnCollectionChangedNotification = false;
                        this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    }
                });
            }
    
            /// <summary>
            /// Override the virtual OnCollectionChanged() method on the ObservableCollection class.
            /// </summary>
            /// <param name="e">Event arguments</param>
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                DoDispatchedAction(() =>
                {
                    if (!DelayOnCollectionChangedNotification)
                        base.OnCollectionChanged(e);
                });
            }
    
            /// <summary>
            /// Makes sure 'action' is executed on the thread that owns the object. Otherwise, things will go boom.
            /// </summary>
            ///<param name="action">The action which should be executed</param>
            private static void DoDispatchedAction(Action action)
            {
                DispatcherHelper.CheckInvokeOnUI(action);
            }
        }
    }
