    static void Main(string[] args)
    {
        var repository = new CarRepository();
        var cars = repository.GetCars().ToArray();
        //make some arbitrary changes...
        cars[0].Make = "Chevy";
        cars[1].Model = "Van";
        //when we call SaveCars, the repository will detect that
        //both of these cars have changed, and write them to the database
        repository.SaveCars(cars);
    }
