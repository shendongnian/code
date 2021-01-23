    public void GetObjectValue<T>(out T destination)
    {
        object paramVal = "Blah.Blah.";
        destination = default(T);
        destination = Convert.ChangeType(paramVal, typeof(T).GetType());
    }
