    public void CarUserMapping_Create(int userId, List<int> carIds)
    {
        using (CUEntities entities = new CUEntities())
        {
            User user = User_GetById(userId);
            entities.Users.Attach(userId);
            foreach (int carId in carIds)
            {
                Car car = Car_GetById(carId);
                car.UserID = user.UserID;
                entities.Entry(car).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }
    }
