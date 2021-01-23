    public class ChangeTrackerCollection<T> : ObservableCollection<T>
    {
        protected override void ClearItems()
        {
            foreach (var item in this)
                UnregisterItemEvents(item);
            base.ClearItems();
        }
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            RegisterItemEvents(item);
        }
        protected override void RemoveItem(int index)
        {
            UnregisterItemEvents(this[index]);
            base.RemoveItem(index);
        }
        private void RegisterItemEvents(T item)
        {
            item.PropertyChanged += this.OnItemPropertyChanged;
        }
        private void UnregisterItemEvents(T item)
        {
            item.PropertyChanged -= this.OnItemPropertyChanged;
        }
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO: raise event to parent object to notify that there was a change...
        }
    }
