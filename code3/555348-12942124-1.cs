    public sealed class ViewModel
    {
        /// <summary>
        /// As this is readonly, the list property cannot change, just it's content so
        /// I don't need to send notify messages.
        /// </summary>
        private readonly ObservableCollection<T> _list = new ObservableCollection<T>();
        /// <summary>
        /// Bind to me.
        /// I publish as IEnumerable<T>, no need to show your inner workings.
        /// </summary>
        public IEnumerable<T> List { get { return _list; } }
        /// <summary>
        /// Add items. Call from a despatch timer if you wish.
        /// </summary>
        /// <param name="newItems"></param>
        public void AddItems(IEnumerable<T> newItems)
        {            
            foreach(var item in newItems)
            {
                _list.Add(item);
            }
        }
        /// <summary>
        /// Sets the list of items. Call from a despatch timer if you wish.
        /// </summary>
        /// <param name="newItems"></param>
        public void SetItems(IEnumerable<T> newItems)
        {
            _list.Clear();
            AddItems(newItems);
        }
    }
