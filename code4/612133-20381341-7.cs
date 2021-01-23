    Car car1 = new Car();
    car1.NeedToBeValidatedRange = 3;  // This will work!
    
    Car car2 = new Car();
    car2.NeedToBeValidatedRange = 6;  // This will throw ValidationException
