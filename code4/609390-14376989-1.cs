    protected void btnsearch_Click(object sender, EventArgs e)
        {
        
            DateTime start = new DateTime(2013,1,5);
            DateTime end = new DateTime(2013,2,2);
        
            string dayName = drpday.SelectedItem.ToString().ToLower();
        
             Dates dt = new Dates();
            List<Dates> list = new List<Dates>();
            int i = 0;
        
           for (DateTime runDate = start; runDate <= end; runDate = runDate.AddDays(1))
            {
                if (runDate.DayOfWeek.ToString().ToLower() == dayName)
                {
                    
                    list.Add(new Dates{
                          FromDate=runDate.ToShortDateString();
                          ToDate=(runDate.AddDays(double.Parse(hd_tourdays.Value)).ToShortDateString());
        });
                   
                }
            }
             grd_TourDates.DataSource = list;
             grd_TourDates.DataBind();
         }
