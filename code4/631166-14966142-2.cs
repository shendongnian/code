    public void Add(object content)
    {
        if (content is IEnumerable)
        {
            foreach (object child in (IEnumerable)content)
                Add(child);
        }
        else
        {
            //process individual element
        }
    }
