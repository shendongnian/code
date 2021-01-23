    public class ValueHolder<T> : INotifyPropertyChanged
    {
        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                if (!EqualityComparer<T>.Default.Equals(value, _value))
                {
                    T old = _value;
                    _value = value;
                    OnPropertyChanged("Value");
                    OnValueChanged(old, value);
                }
            }
        }
        public ValueHolder()
        {
        }
        public ValueHolder(T value)
        {
            this._value = value;
        }
        public event EventHandler<ValueChangedEventArgs<T>> ValueChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnValueChanged(T oldValue, T newValue)
        {
            var h = ValueChanged;
            if (h != null)
                h(this, new ValueChangedEventArgs<T>(oldValue, newValue));
        }
        protected virtual void OnPropertyChanged(string propName)
        {
            var h = PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(propName));
        }
    }
    public class ValueChangedEventArgs<T> : EventArgs
    {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
        public ValueChangedEventArgs(T oldValue, T newValue)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
    public class MyCollection<T> : Collection<ValueHolder<T>>
    {
        public void Add(T i)
        {
            this.Add(new ValueHolder<T>(i));
        }
        private void AddChangeHandler(ValueHolder<T> item)
        {
            item.ValueChanged += item_ValueChanged;
        }
        private void RemoveChangeHandler(ValueHolder<T> item)
        {
            item.ValueChanged -= item_ValueChanged;
        }
        protected override void InsertItem(int index, ValueHolder<T> item)
        {
            AddChangeHandler(item);
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            RemoveChangeHandler(this[index]);
            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                RemoveChangeHandler(item);
            }
            base.ClearItems();
        }
        protected override void SetItem(int index, ValueHolder<T> item)
        {
            RemoveChangeHandler(this[index]);
            AddChangeHandler(item);
            base.SetItem(index, item);
        }
        private void item_ValueChanged(object sender, ValueChangedEventArgs<T> e)
        {
            ValueHolder<T> v = (ValueHolder<T>)sender;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] == v)
                    continue;
                if (EqualityComparer<T>.Default.Equals(this[i].Value, e.NewValue))
                {
                    this[i].Value = e.OldValue;
                    break;
                }
            }
        }
    }
