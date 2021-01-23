    List<Car> cars = new List<Car>();
    while(reader.read())
    {
         Car newCar = new Car();
         newCar.UserId = Convert.ToInt32(reader["UserId"]); //Should probably use TryParse here, but I will use ToInt32 for simplicity sake
         //same for other columns
         cars.Add(newCar);
    }
