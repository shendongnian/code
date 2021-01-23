    int day= 31; 
    int month = 12;
    bool IsMonday =false;
    string fdate = day.Tostring() + "/"+month.Tostring()+ "/" + System.DateTime.Today.Year;
    while(IsMonday )
    {   
     
        if(DayOfWeek.Monday == (DateTime.ParseExact(fdate , "d", CultureInfo.InvariantCulture)).DayOfWeek) {
            IsMonday = true;
        } else {
            if(day==31){
                day= 1;
                month =1;
            } else {
                day= day+1;
                month =1;
            }
            fdate = day.Tostring() + "/"+month.Tostring()+ "/" + System.DateTime.Today.Year;
        }
    }
    string ffdate = "";
    string ttdate = "";
    for (int date = 0; date < 365; date=date+7 ){
        ffdate += Convert.ToDateTime(fdate).AddDays(date).ToString() + ",";        
        ttdate += Convert.ToDateTime(fdate).AddDays(Convert.ToInt32(txtTime.Text)).ToString() + ",";
    }
    fromdate = ffdate.TrimEnd(',');
    todate = ttdate.TrimEnd(',');
