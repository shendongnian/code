    if(value == null)
    {
      throw new ArgumentNullException("value");
    }
    DateTime dt ;
    if(value is DateTime)
    {
       dt = (DateTime)value;
    }
    else
    {
      string format = "dd/MM/yyyy HH:mm:ss";
      DateTime.TryParseExact(value.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
    }
    //rest of your code
