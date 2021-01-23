    protected void btnsearch_Click(object sender, EventArgs e)
    {
         Dates dt;
        List<Dates> list = new List<Dates>();
        int i = 0;
    
       for (DateTime runDate = start; runDate <= end; runDate = runDate.AddDays(1))
        {
            if (runDate.DayOfWeek.ToString().ToLower() == dayName)
            {
                dt = new Dates()
                dt.FromDate = runDate.ToShortDateString();
                dt.ToDate = (runDate.AddDays(double.Parse(hd_tourdays.Value)).ToShortDateString());
                list.Insert(i++,dt);
            }
        }
         grd_TourDates.DataSource = list;
         grd_TourDates.DataBind();
     }
