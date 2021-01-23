    DateTime myDate;
    if(DateTime.TryParse("Saturday 04/23/2013 11:05 PM", out myDate))
    {
       if (myDate < DateTime.Today) { //code here }
    }
    else
    {
       //Do something here for invalid data
    }
