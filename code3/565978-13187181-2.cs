    class Scheduler
    {
        readonly IFromToDateProvider _provider;
        public Scheduler(IFromToDateProvider provider)
        {
            _provider = provider;
            _provider.PropertyChanged += provider_PropertyChanged;
        }
        void provider_PropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            // update display with new values in _provider.From and/or 
            // _provider.To in this event handler
        }
    }
