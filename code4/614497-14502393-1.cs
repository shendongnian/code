    public class MyDependantClass
    {
        public MyDependantClass(IInjectedObject injectedObject)
        {
            InjectedObject = injectedObject;
        }
        // We wrap the private field in a protected property,
        // to capture the event subscriptions
        private IInjectedObject _injectedObject;
        protected IInjectedObject InjectedObject
        {
            get { return _injectedObject; }
            set
            {
                if(_injectedObject != null)
                    _injectedObject.MyImportantPropertyChanged -= OnMyPropChanged;
                _injectedObject = value;
                if(_injectedObject != null)
                   _injectedObject.MyImportantPropertyChanged += OnMyPropChanged;
            }
        }
        private void OnMyPropChanged(object sender, EventArgs args)
        {
            //react to the changed property here!
        }
    }
