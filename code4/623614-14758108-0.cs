    public void CarUserMapping_Create(int userId, List<int> carIds)
    {
        using (CUEntities entities = new CUEntities())
        {
            User user = User_GetById(userId);
            entities.Users.Attach(userId);
            foreach (int carId in carIds)
            {
                Car car = Car_GetById(carId);
                
                //this to let the EF context know the car already exists
                entities.Cars.Attach(car);
                user.Cars.Add(car);
                //I'm not even sure you'll neeed the following line?
                entities.ObjectStateManager.ChangeObjectState(user, System.Data.EntityState.Modified);
                entities.SaveChanges();
            }
        }
    }
