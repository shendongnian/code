    public class CarRepository
    {
        private ChangeTracker<Car> _cars = new ChangeTracker<Car>();
        
        public IEnumerable<Car> GetCars()
        {
            //TODO: JET/ADO code here
            //TODO: create or update car objects by calling _cars.IsTracking
            //      and then calling _cars.StartTracking where necessary
            return _cars.GetTrackedItems();
        }
        public void SaveCars(IEnumerable<Car> cars)
        {
            var changedItems = _cars.GetChangedItems().Intersect(cars);
            var newItems = cars.Except(_cars.GetTrackedItems());
            //TODO: JET/ADO code here to create/update items above
            
            _cars.SetNewCheckpoint();
        }
    }
