        protected override void RemoveItem(int index)
        {
            this[index] = new EngineStatusUserFilter();
            base.RemoveItem(index);
            Refresh();
        }
        public void Refresh() {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)); } 
