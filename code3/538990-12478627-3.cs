    public class CarController : ICarController
    {
         private readonly ICarRepository _carRepository;
    
         public CarController(ICarRepository carRepository)
         {
             _carRepository = carRepository;
         }
    
         public void SaveCar(ICar car)
         {
              _carRepository.SaveCar(car);
         }
    }
