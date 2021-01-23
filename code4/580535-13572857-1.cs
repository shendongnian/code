    public void Test()
    {
        // This works:
        var fords = new List<Car> {new Ford()};
        FixCars(fords);
        // This does not work (since you cannot pass non car-typed list):
        // var mustangs = new List<Ford> {new Ford()};
        // FixCars(fords);
    }
    public void FixCars(List<Car> list)
    {
        // Do stuff
    }
    public class Car 
    {    
    }
    public class Ford : Car
    {
    }
