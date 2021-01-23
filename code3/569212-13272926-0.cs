    public bool Compare(object value1, object value2)
    {
        if (value1.GetType() == value2.GetType())
        {
            return value1.Equals(value2);
        }
        else
        {
            //your logic for handling different numbers
        }
    }
