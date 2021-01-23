    Double someValue;
    DateTime date;
    while (pReader.Read())
    {
       someValue = pReader.GetDouble(0);
       date = pReader.GetDate(1);
       var someObject = new someObject(someValue, someDate);
       someObjects.Add(comeObject);
    }
    //or
    while (pReader.Read())
    {
       someObjects.Add(new someObject(pReader.GetDouble(0), pReader.GetDate(1)));
    }
