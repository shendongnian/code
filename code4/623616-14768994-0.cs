    using (CUEntities entities = new CUEntities())
    {
        User user = User_GetById(entities , userId);
    
    
        foreach (int carId in carIds)
        {
            Car car = Car_GetById(entities, carId);
            car.UserID = user.UserID;
            entities.SaveChanges();
        }
    }
