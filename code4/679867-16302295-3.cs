    public static Entity GetById(int id)
    {
        using(var entities = new MyEntities())
        {
            return entities.someTable
                           .FirstOrDefault(row => row.Id == id);
        }
    }
