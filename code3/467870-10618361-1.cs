    public struct Age
    {
        private readonly Int32 _years;
        private readonly Int32 _months;
        private readonly Int32 _days;
        private readonly Int32 _totalDays;
    
        /// <summary>
        /// Initializes a new instance of <see cref="Age"/>.
        /// </summary>
        /// <param name="start">The date and time when the age started.</param>
        /// <param name="end">The date and time when the age ended.</param>
        /// <remarks>This </remarks>
        public Age(DateTime start, DateTime end)
            : this(start, end, CultureInfo.CurrentCulture.Calendar)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of <see cref="Age"/>.
        /// </summary>
        /// <param name="start">The date and time when the age started.</param>
        /// <param name="end">The date and time when the age ended.</param>
        /// <param name="calendar">Calendar used to calculate age.</param>
        public Age(DateTime start, DateTime end, Calendar calendar)
        {
            if (start > end) throw new ArgumentException("The starting date cannot be later than the end date.");
    
            var startDate = start.Date;
            var endDate = end.Date;
    
            _years = _months = _days = 0;
            _days += calendar.GetDayOfMonth(endDate) - calendar.GetDayOfMonth(startDate);
            if (_days < 0)
            {
                _days += calendar.GetDaysInMonth(calendar.GetYear(startDate), calendar.GetMonth(startDate));
                _months--;
            }
            _months += calendar.GetMonth(endDate) - calendar.GetMonth(startDate);
            if (_months < 0)
            {
                _months += calendar.GetMonthsInYear(calendar.GetYear(startDate));
                _years--;
            }
            _years += calendar.GetYear(endDate) - calendar.GetYear(startDate);
    
            var ts = endDate.Subtract(startDate);
            _totalDays = (Int32)ts.TotalDays;
        }
    
        /// <summary>
        /// Gets the number of whole years something has aged.
        /// </summary>
        public Int32 Years
        {
            get { return _years; }
        }
    
        /// <summary>
        /// Gets the number of whole months something has aged past the value of <see cref="Years"/>.
        /// </summary>
        public Int32 Months
        {
            get { return _months; }
        }
    
        /// <summary>
        /// Gets the age as an expression of whole months.
        /// </summary>
        public Int32 TotalMonths
        {
            get { return _years * 12 + _months; }
        }
    
        /// <summary>
        /// Gets the number of whole weeks something has aged past the value of <see cref="Years"/> and <see cref="Months"/>.
        /// </summary>
        public Int32 Days
        {
            get { return _days; }
        }
    
        /// <summary>
        /// Gets the total number of days that have elapsed since the start and end dates.
        /// </summary>
        public Int32 TotalDays
        {
            get { return _totalDays; }
        }
    
        /// <summary>
        /// Gets the number of whole weeks something has aged past the value of <see cref="Years"/> and <see cref="Months"/>.
        /// </summary>
        public Int32 Weeks
        {
            get { return (Int32) Math.Floor((Decimal) _days/7); }
        }
    
        /// <summary>
        /// Gets the age as an expression of whole weeks.
        /// </summary>
        public Int32 TotalWeeks
        {
            get { return (Int32) Math.Floor((Decimal) _totalDays/7); }
        }
    }
