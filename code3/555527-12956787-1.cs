    public static bool Save<T>(T entity, string msg) where T : IEntity, new()
    {
        string possibleError;
        switch (entity.Manager<T>().Save(entity, out possibleError))
        {
            //--------------------------------------
        }
        return true;
    }
