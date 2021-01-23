    public class CarRepository
    {
        private ChangeTracker<Car> _cars = new ChangeTracker<Car>();
        
        public IEnumerable<Car> GetCars()
        {
            //TODO: JET/ADO code here, you would obviously do in a for/while loop
            int dbId1 = 1;
            string make1 = "Ford";
            string model1 = "Focus";
            //TODO: create or update car objects
            Car car1;
            if (!_cars.IsTracking(dbId1))
                car1 = new Car();
            else
                car1 = _cars.GetItem(dbId1);
            car1.Make = make1;
            car1.Model = model1;
            if (!_cars.IsTracking(dbId1))
                _cars.StartTracking(dbId1, car1);
            return _cars.GetTrackedItems();
        }
        public void SaveCars(IEnumerable<Car> cars)
        {
            foreach (var changedItem in _cars.GetChangedItems().Intersect(cars))
            {
                //TODO: JET/ADO code here to update the item
            }
            foreach (var newItem in cars.Except(_cars.GetTrackedItems()))
            {
                //TODO: JET/ADO code here to add the item to the DB and get its new ID
                int newId = 5;
                _cars.StartTracking(newId, newItem);
            }            
            _cars.SetNewCheckpoint();
        }
    }
