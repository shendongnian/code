    public List<Entity> GetEntities()
    {
        using (var context = new CensusEntities())
        {
            return (from e in context.Entities
                select new Entity
                {
                    col1 = e.col1,
                    col4 = e.col4,
                    col5 = e.col5,
                }
            ).ToList();
        }
    }
