    public class BindingListFixed<T> : BindingList<T>
    {
        [NonSerialized]
        private readonly bool _fix;
        public BindingListFixed()
        {
            _fix = !typeof (INotifyPropertyChanged).IsAssignableFrom(typeof (T));
        }
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            if (RaiseListChangedEvents && _fix)
            {
                var c = item as INotifyPropertyChanged;
                if (null!=c)
                    c.PropertyChanged += FixPropertyChanged;
            }
        }
        protected override void RemoveItem(int index)
        {
            var item = base[index] as INotifyPropertyChanged;
            base.RemoveItem(index);
            if (RaiseListChangedEvents && _fix && null!=item)
            {
                item.PropertyChanged -= FixPropertyChanged;
            }
        }
        void FixPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!RaiseListChangedEvents) return;
            
            if (_itemTypeProperties == null)
            {
                _itemTypeProperties = TypeDescriptor.GetProperties(typeof(T));
            }
            var propDesc = _itemTypeProperties.Find(e.PropertyName, true);
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, IndexOf((T)sender), propDesc));
        }
        [NonSerialized]
        private PropertyDescriptorCollection _itemTypeProperties;
    }
