    for (int index = 0; index < carInfos.Count/6; index++)
    {
        int offest = index * 6;
        Cars.AllCars.Add(new CarModel{
                                     Plate = carInfos[0 + offest].Value,
                                     Type = carInfos[1 + offest].Value,
                                     NetWorth = int.Parse(carInfos[3 + offest].Value,
                                     etc, etc..    
                                     });
    }
