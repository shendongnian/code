        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // Prevent infinite loop that could occur if handler changes the collection
            using (BlockReentrancy())
            {
                if (!m_fSuppressNotifications)
                {
                    // Get the current event
                    var oCollectionChangedEvent = this.CollectionChanged;
                    if (oCollectionChangedEvent != null)
                    {
                        foreach (EventHandler oHandler in oCollectionChangedEvent.GetInvocationList())
                        {
                            // Execute the handler
                            oHandler(this, e);
                        }
                    }
                }
            }
        }
