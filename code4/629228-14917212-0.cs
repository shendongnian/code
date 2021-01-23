    DateTime myObject;
    DateTime.TryParse(inputString, out myObject)
    {
        if (myObject == DateTime.MinValue)
        {
            //string doesn't have a date time
        }
    }
