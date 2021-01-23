    const string DATE_TIME_FORMAT = "<your format>";
    [DataMember]
    string myDate;
    public DateTime MyDate {
      get 
      {
        return DateTime.ParseExact(myDate, DATE_TIME_FORMAT, CultureInfo.CurrentCulture);
      }
      set 
      {
        myDate = value.ToString(DATE_TIME_FORMAT);
      }
    }
