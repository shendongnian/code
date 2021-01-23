    protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
                if (e.Day.Date > startDate && 
                    e.Day.Date < finishDate     ) //Adjust your condition on  e.Day.Date
                {
                    e.Cell.BackColor = System.Drawing.Color.Green; //Highligth ; adjust your color
                }
            }
        }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e) 
    {
       if(startDate == null)
         startDate = Calendar1.SelectedDate;
       else
         finishDate = Calendar1.SelectedDate;      
    }
    <asp:Calendar OnDayRender="Calendar_DayRender" />
