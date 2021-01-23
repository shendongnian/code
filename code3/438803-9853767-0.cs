    public class PrestoObservableCollection<T> : ObservableCollection<T>
        {
            private bool _delayOnCollectionChangedNotification { get; set; }
    
            /// <summary>
            /// Add a range of IEnumerable items to the observable collection and optionally delay notification until the operation is complete.
            /// </summary>
            /// <param name="itemsToAdd"></param>
            public void AddRange(IEnumerable<T> itemsToAdd)
            {
                if (itemsToAdd == null) throw new ArgumentNullException("itemsToAdd");
    
                if (itemsToAdd.Any() == false) { return; }  // Nothing to add.
    
                _delayOnCollectionChangedNotification = true;            
    
                try
                {
                    foreach (T item in itemsToAdd) { this.Add(item); }
                }
                finally
                {
                    ResetNotificationAndFireChangedEvent();
                }
            }
    
            /// <summary>
            /// Clear the items in the ObservableCollection and optionally delay notification until the operation is complete.
            /// </summary>
            public void ClearItemsAndNotifyChangeOnlyWhenDone()
            {
                try
                {
                    if (!this.Any()) { return; }  // Nothing available to remove.
    
                    _delayOnCollectionChangedNotification = true;
    
                    this.Clear();
                }
                finally
                {
                    ResetNotificationAndFireChangedEvent();
                }
            }
    
            /// <summary>
            /// Override the virtual OnCollectionChanged() method on the ObservableCollection class.
            /// </summary>
            /// <param name="e">Event arguments</param>
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                if (_delayOnCollectionChangedNotification) { return; }
                
                base.OnCollectionChanged(e);
            }
    
            private void ResetNotificationAndFireChangedEvent()
            {
                // Turn delay notification off and call the OnCollectionChanged() method and tell it we had a change in the collection.
                _delayOnCollectionChangedNotification = false;
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
