    private List<T> MyMethod<T>()
    {
        List<T> lst = new List<T>;
        foreach (T type in Enum.GetValues(source.GetType()))
        {
            lst.Add(type); 
        }
       return lst;
    }
