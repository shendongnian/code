    public class MyDependantClass
    {
        public MyDependantClass(IInjectedObject injectedObject)
        {
            MyInjectedObject = injectedObject;
        }
        // We wrap the private field in a protected property,
        // to capture the event subscriptions
        private IInjectedObject _myInjectedObject;
        protected IInjectedObject MyInjectedObject
        {
            get { return _myInjectedObject; }
            set
            {
                // unsubscribe from the old property's event
                if(_myInjectedObject!= null)
                    _myInjectedObject.PropertyChanged -= OnPropertyChanged;
                _myInjectedObject= value;
                // subscribe to the new property's event
                if(_myInjectedObject!= null)
                   _myInjectedObject.PropertyChanged += OnPropertyChanged;
            }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == "MyImportantProperty")
            {
                //react to the changed property here!
            }
        }
    }
