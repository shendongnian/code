    public void Add(object content)
    {
        if (content is IEnumerable)
        {
            foreach (object child in (IEnumerable)content)
                Add(child);
        }
            //may end up checking for other collection types
        else
        {
            //process individual element
        }
    }
