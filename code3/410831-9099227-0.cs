    // The car class itself
    public class Car
    {
        // This event is raised when the production property changes
        public event EventHandler<PropertyValueChange<DateTime>> ProductionChanged;
        DateTime _production; // private data
        public DateTime Production
        {
            get { return _production; }
            set
            {
                if (value == _production) return; // don't raise the event if it didn't change
                var eventArgs = new PropertyValueChange<DateTime>(_production, value);
                _production = value;
                // If anyone is "listening," raise the event
                if (ProductionChanged != null)
                    ProductionChanged(this, eventArgs);
            }
        }
    }
    // Class that contains the dictionary of production to car lists
    class Foo
    {
        Dictionary<DateTime, ObservableCollection<Car>> ProductionToCars = new Dictionary<DateTime, ObservableCollection<Car>>();
        public void Add(Car c)
        {
            _Add(c);
            // We want to be notified when the car's production changes
            c.ProductionChanged += this.OnCarProductionChanged;
        }
        // This is called when a car's value changes, and moves the car
        void OnCarProductionChanged(object sender, PropertyValueChange<DateTime> e)
        {
            Car c = sender as Car;
            if (c == null) return;
            ProductionToCars[e.OldValue].Remove(c);
            _Add(c);
        }
        // this actually places the car in the (currently correct) group
        private void _Add(Car c)
        {
            ObservableCollection<Car> collection;
            // Find the collection for this car's year
            if (!ProductionToCars.TryGetValue(c.Production, out collection))
            {
                // if we couldn't find it, create it
                collection = new ObservableCollection<Car>();
                ProductionToCars.Add(c.Production, collection);
            }
            // Now place him in the correct collection
            collection.Add(c);
        }
    }
    // This class encapsulates the information we'll pass when the property value changes
    public class PropertyValueChange<T> : EventArgs
    {
        public T OldValue;
        public T NewValue;
        public PropertyValueChange(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
