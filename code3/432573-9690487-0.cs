    private static HashSet<Type> initializedTypes = new HashSet<Type>();
    public BaseClass()
    {
        if (!initializedTypes.Contains(this.GetType())
        {
            //Do something here
            initializedTypes.Add(this.GetType());
        }
    }
