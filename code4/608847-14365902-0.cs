    class PropertyStorageContainerViewModel : INotifyPropertyChanged
    {
        private PropertyStorageContainer model;
        public PropertyStorageContainerViewModel(PropertyStorageContainer model)
        {
            this.model = model;
        }
        public string Property
        {
            get
            {
                if (model != null)
                {
                    return model.Property;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (model.Property != value)
                {
                    model.Property = value;
                    RaisePropertyChanged("Property");
                }
            }
        } 
        // INotifyPropertyChanged implementation...
    }
