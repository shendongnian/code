    class DelegateContainer
    {
        public DelegateContainer(Action theAction, string propName)
        {
             TheAction = theAction;
             PopertyName = propName;
        }
        public Action TheAction { get; private set; }
        public string PropertyName { get; private set; }
 
        public void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if(PropertyName == e.PropertyName)
                TheAction();
        }
    }
