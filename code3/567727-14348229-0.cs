    public void SaveAll<T>(IEnumerable<T> objects)
    {
        foreach (object obj in objects)
        {
            T specificObject = (T)obj;
            Session.Save(specificObject);
        }
        Session.Flush();
    }
