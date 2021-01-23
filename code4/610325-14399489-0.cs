    public void ADDUSociate(UserClientEntity entity)
    {
        this.AddObject("UserEntities", entity);
        this.SaveChanges();
    }
