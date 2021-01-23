    [ActionName("GetDocByDate")]
    public IEnumerable<Car> Get() {
        IEnumerable<Car> cars = _carRepository.GetAll().ToList();
        return cars;
    }
