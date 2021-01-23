    class DelegateContainer
    {
        public Action TheAction { get; set; }
        public string PropertyName { get; set; }
 
        public void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if(PropertyName == e.PropertyName)
                TheAction();
        }
    }
