    protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
                if (e.Day.Date > startDate && 
                    e.Day.Date < finishDate     ) //Adjust your condition on  e.Day.Date
                {
                    e.Cell.BackColor = System.Drawing.Color.Green; //Highligth ; adjust your color
                }
            }
        }
    <asp:Calendar OnDayRender="Calendar_DayRender" />
