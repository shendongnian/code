    public IEntity RetrieveEntity(T userParam)
    {
        FirstClass firstClass = new FirstClass();
        if (userParam is string)
            return firstClass.GetEntity((string)(object)userParam);
        else if (userParam is int)
            return firstClass.GetEntity((int)(object)userParam);
        else
            return null; // or new IEntity();
    }
