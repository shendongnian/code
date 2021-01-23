    class ParentVM
    {
        private ChildVM _childVM = new ChildVM();
        public ParentVM()
        {
            _childVM.PropertyChanged += SomeHandler;
        }
        public ChildVM ChildVM
        {
            get
            {
                return _childVM;
            }
            set
            {
                foreach (var handler in _childVM.GetPropertyChangedHandlers())
                {
                    _childVM.PropertyChanged -= handler;
                    value.PropertyChanged += handler;
                }
                _childVM = value;
            }
        }
        private void SomeHandler(object sender, PropertyChangedEventArgs e)
        {
        }
    }
    class ChildVM : INotifyPropertyChanged
    {
        public PropertyChangedEventHandler[] GetPropertyChangedHandlers()
        {
            return PropertyChanged.GetInvocationList().
                   OfType<PropertyChangedEventHandler>().ToArray();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
