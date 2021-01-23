    int Date = 31; 
    int month = 12;
    bool IsMonday =false;
    string fdate = Date.Tostring() + "/"+month.Tostring()+ "/" + System.DateTime.Today.Year;
    while(IsMonday )
    {   
     
        if(DayOfWeek.Monday == (DateTime.ParseExact(fdate , "d", CultureInfo.InvariantCulture)).DayOfWeek)
       {
        IsMonday = true;
       }
       else
       {
          if(Date ==31)
            {
             date = 1;
             month =1;
            }
          else
            {
            date  = date  +1;
            month =1;
            }
          fdate = Date.Tostring() + "/"+month.Tostring()+ "/" + System.DateTime.Today.Year;
         }
       
     }
          string ffdate = "";
          string ttdate = "";
    for (int date = 0; date < 365; date=date+7 )
    {
        ffdate += Convert.ToDateTime(fdate).AddDays(date).ToString() + ",";
        date += Convert.ToInt32(txtTime.Text);
        ttdate += Convert.ToDateTime(fdate).AddDays(date).ToString() + ",";
    }
    fromdate = ffdate.TrimEnd(',');
    todate = ttdate.TrimEnd(',');
