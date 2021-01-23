    public void ChangeCarOwner(Person originalOwner, Person newOwner, int carId)
    {
        Car car = originalOwner.RemoveCarOwnership(carId);
        newOwner.AddCarOwnership(car);
    }
    public class Person
    {
        ...
        public Car RemoveCarOwnership(int carId)
        {
            Car car = this.Cars.Single(c => c.Id == carId);
            this.Cars.Remove(car);
            return car;
        }
    }
