    // Option 1, a Property Bag (Note: this replaces the properties on the classes)
    class Asset
    {
        Dictionary<string, object> myPropertyBag = new Dictionary<string, object>();
        public T GetProperty<T>(string property)
        {
            // This throws if the property doesn't exist
            return (T)myPropertyBag[property];
        }
        public void SetProperty<T>(string property, T value)
        {
            // This adds the property if it doesn't exist
            myPropertyBag[property] = (object)value;
        }
    }
    // Option 2, use a switch and override this function in derived classes
    class Asset
    {
        public int SomePropertyOnAsset { get; set; }
        public virtual T GetProperty<T>(string property)
        {
            switch (property)
            {
                case "SomePropertyOnAsset": return this.SomePropertyOnAsset;
                default: throw new ArgumentException("property");
            }
        }
        public virtual void SetProperty<T>(string property, T value)
        {
            switch (property)
            {
                case "SomePropertyOnAsset": this.SomePropertyOnAsset = (int)value;
                default: throw new ArgumentException("property");
            }
        }
    }
    class House : Asset
    {
        public int Rooms { get; set; }
        public virtual T GetProperty<T>(string property)
        {
            switch (property)
            {
                case "Rooms": return this.Rooms;
                default: return base.GetProperty<T>(property);
            }
        }
        public virtual void SetProperty<T>(string property, T value)
        {
            switch (property)
            {
                case "Rooms": this.Rooms = (int)value; 
                    break;
                default: base.SetProperty<T>(property, value);
                    break;
            }
        }
    }
