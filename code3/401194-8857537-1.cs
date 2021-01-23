    CarsCollection cars = new CarsCollection
    {
        new Cars{ Brand = "BMW", Model = "7.20" },
        new Cars{ Brand = "Mercedes", Model = "CLK" }
    };
    // note that you cannot serialize the entire list if
    // you want to query without loading - it must be symmetrical
    StreamSerializer.Serialize(cars, "data.bin");
    // the following expression iterates through objects, processing one 
    // at a time. "First" method is a good example because it
    // breaks early.
    var bmw = StreamSerializer
        .Deserialize<Cars>("data.bin")
        .First(c => c.Brand == "BMW");
