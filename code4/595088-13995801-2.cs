    class SelectionChangedMessage 
    {
        public object NewValue { get; private set; }
        public SelectionChangedMessage(object newValue) 
        {
            NewValue = newValue;
        }
    }
