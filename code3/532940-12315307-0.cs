    public int GetNumberWithName(string name, NWRevalDatabaseEntities entities)
    {
        int number = ExecuteQuery(entities, Name);
        return number;
    }
