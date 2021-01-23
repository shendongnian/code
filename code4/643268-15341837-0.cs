    public class LocalizedWeekPicker : LocalizedDatePicker
    {
        /// <summary>
        /// An LocalizedDatePicker that disallows selecting any date that does not have the same DOW as the FirstDayOfWeek property.
        /// It does this by disabling the dates N (currently=10) years forward and backward from today as well as automatically updating the date
        /// if you choose something more than 10 years away from today.
        /// </summary>
        public LocalizedWeekPicker() : base()
        {
            this.Loaded += (s1, a1) => {
                this.IsTodayHighlighted = false;
                if (SelectedDate.HasValue)
                {
                    var tempDate = new DateTime(SelectedDate.Value.Ticks);
                    SelectedDate = DateTimeUtils.GetPreviousDateOnDayOfWeek(FirstDayOfWeek, tempDate);
                }
                DisableDays();
                
                this.SelectedDateChanged += (s2, a2) => {
                    var tempDate = new DateTime(((DateTime)a2.AddedItems[0]).Ticks);
                    SelectedDate = DateTimeUtils.GetPreviousDateOnDayOfWeek(FirstDayOfWeek, tempDate);
                };
            };
        }
        // goes forward and back n years and disables dates that don't have the same start DOW as the FirstDayOfWeek
        private void DisableDays()
        {
            int years = 10;
            var current = DateTimeUtils.GetPreviousDateOnDayOfWeek(FirstDayOfWeek, DateTime.Now);
            for (int weeks = 0; weeks < (52 * years); weeks++)
            {
                this.BlackoutDates.Add(new CalendarDateRange {Start = current.AddDays(1), End = current.AddDays(6)});
                current = current.AddDays(7);
            }
            
            current = DateTimeUtils.GetPreviousDateOnDayOfWeek(FirstDayOfWeek, DateTime.Now);
            for (int weeks = 0; weeks < (52 * years); weeks++)
            {
                this.BlackoutDates.Add(new CalendarDateRange { Start = current.AddDays(1), End = current.AddDays(6) });
                current = current.AddDays(-7);
            }
        }
    }
