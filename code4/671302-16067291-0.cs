    DateTime dt;
    var isDate = DateTime.TryParse(strMyDate, out dt);
    if(isDate)
    {
       var time = dt.Add(DateTime.Now.TimeOfDay);
    }
