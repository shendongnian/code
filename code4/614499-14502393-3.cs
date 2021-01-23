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
                    _myInjectedObject.MyImportantPropertyChanged -= OnMyPropChanged;
                _myInjectedObject= value;
                // subscribe to the new property's event
                if(_myInjectedObject!= null)
                   _myInjectedObject.MyImportantPropertyChanged += OnMyPropChanged;
            }
        }
        private void OnMyPropChanged(object sender, EventArgs args)
        {
            //react to the changed property here!
        }
    }
