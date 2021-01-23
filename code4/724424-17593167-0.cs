    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading;
    
    namespace WindowsFormsApplication4
    {
    public sealed class NestedBindingProxy : INotifyPropertyChanged
    {
        class PropertyChangeListener
        {
            private readonly PropertyDescriptor _prop;
            private readonly WeakReference _prevOb = new WeakReference(null);
            public event EventHandler ValueChanged;
            public PropertyChangeListener(PropertyDescriptor property)
            {
                _prop = property;
            }
            public object GetValue(object obj)
            {
                return _prop.GetValue(obj);
            }
            public void SubscribeToValueChange(object obj)
            {
                if (_prop.SupportsChangeEvents)
                {
                    _prop.AddValueChanged(obj, ValueChanged);
                    _prevOb.Target = obj;
                }
            }
            public void UnsubsctribeToValueChange()
            {
                var prevObj = _prevOb.Target;
                if (prevObj != null)
                {
                    _prop.RemoveValueChanged(prevObj, ValueChanged);
                    _prevOb.Target = null;
                }
            }
        }
        private readonly object _source;
        private PropertyChangedEventHandler _subscribers;
        private readonly List<PropertyChangeListener> _properties = new List<PropertyChangeListener>();
        private readonly SynchronizationContext _synchContext;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                bool hadSubscribers = _subscribers != null;
                _subscribers += value;
                bool hasSubscribers = _subscribers != null;
                if (!hadSubscribers && hasSubscribers)
                {
                    ListenToPropertyChanges(true);
                }
            }
            remove
            {
                bool hadSubscribers = _subscribers != null;
                _subscribers -= value;
                bool hasSubscribers = _subscribers != null;
                if (hadSubscribers && !hasSubscribers)
                {
                    ListenToPropertyChanges(false);
                }
            }
        }
        public NestedBindingProxy(object source, string nestedPropertyPath)
        {
            _synchContext = SynchronizationContext.Current;
            _source = source;
            var propNames = nestedPropertyPath.Split('.');
            Type type = source.GetType();
            foreach (var propName in propNames)
            {
                var prop = TypeDescriptor.GetProperties(type)[propName];
                var propChangeListener = new PropertyChangeListener(prop);
                _properties.Add(propChangeListener);
                propChangeListener.ValueChanged += (sender, e) => OnNestedPropertyChanged(propChangeListener);
                type = prop.PropertyType;
            }
        }
        public object Value
        {
            get
            {
                object value = _source;
                foreach (var prop in _properties)
                {
                    value = prop.GetValue(value);
                    if (value == null)
                    {
                        return null;
                    }
                }
                return value;
            }
        }
        private void ListenToPropertyChanges(bool subscribe)
        {
            if (subscribe)
            {
                object value = _source;
                foreach (var prop in _properties)
                {
                    prop.SubscribeToValueChange(value);
                    value = prop.GetValue(value);
                    if (value == null)
                    {
                        return;
                    }
                }
            }
            else
            {
                foreach (var prop in _properties)
                {
                    prop.UnsubsctribeToValueChange();
                }
            }
        }
        private void OnNestedPropertyChanged(PropertyChangeListener changedProperty)
        {
            ListenToPropertyChanges(false);
            ListenToPropertyChanges(true);
            var subscribers = _subscribers;
            if (subscribers != null)
            {
                if (_synchContext != SynchronizationContext.Current)
                {
                    _synchContext.Post(delegate { subscribers(this, new PropertyChangedEventArgs("Value")); }, null);
                }
                else
                {
                    subscribers(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }
    }
}
