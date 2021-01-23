        private bool m_fSuppressNotifications;
        public void AddRange(List<Foo> cItems)
        {
            if ((cItems == null) || (cItems.Count == 0)) {
                this.Clear();
            } else {
                try
                {
                    // Keep events from being fired
                    m_fSuppressNotifications = true;
                    foreach (var oFoo in cItems)
                    {
                        this.Add(oFoo);
                    }
                }
                finally
                {
                    m_fSuppressNotifications = false;
                    // Raise the event to notify any listeners that the data has changed
                    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
                }
            }
        }
