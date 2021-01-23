        protected void WeekendDays_Button_Click(object sender, EventArgs e)
        {
            this.SelectWeekEnds():
        }
        private void SelectWeekEnds(){
            //If you need to get the selected date from calendar
            //DateTime dt = this.Calendar1.SelectedDate;
            //If you need to get the current date from today
            DateTime dt = DateTime.Now;
            List<DateTime> weekendDays = this.SelectedWeekEnds(dt);
            weekendDays.ForEach(d => this.Calendar1.SelectedDates.Add(d));
        }
        private List<DateTime> GetWeekEndDays(DateTime DT){
            List<DateTime> result = new List<DateTime>();
            int month = DT.Month;
            DT = DT.AddDays(-DT.Day+1);//Sets DT to first day of month
            //Sets DT to the first week-end day of the month;
            if(DT.DayOfWeek != DayOfWeek.Sunday)
                while (DT.DayOfWeek != DayOfWeek.Saturday)
                    DT = DT.AddDays(1);
            //Adds the week-end day and stops when next month is reached.
            while (DT.Month == month)
            {
                result.Add(DT);
                DT = DT.AddDays(DT.DayOfWeek == DayOfWeek.Saturday ? 1 : 6);
            }
            return result;
        }
