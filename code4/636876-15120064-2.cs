    public interface ICarService
    {
        Car FindById(int carId);
    }
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }
        #region Implementation of ICarService
        public Car FindById(int carId)
        {
            var car = _repository.FindById(carId);
            // The additional business logic (if required) could be added here.
            return car;
        }
        #endregion
    }
