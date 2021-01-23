     private void display_weather_from_db(DateTime Weather_Startdate)
     {
     Label[] Calendar_Weekday_Day = this.TabControl1.Controls.OfType<Label>().Where(X=>X.Tag!=null && X.Tag=="Weather").ToArray();
     Calendar_Weekday_Day[0].Text = "Test1";
     Calendar_Weekday_Day[1].Text = "Test2";
     }
