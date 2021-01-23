    public class DateLabel : Label
    {
        private DateTime? _date;
    
        public DateLabel()
        {
            Format = "dd MMMM dddd";
            TodayForeColor = Color.Red;
        }
    
        public DateTime? Date
        {
            get { return _date; }
            set {
                _date = value;
                Text = _date.HasValue ? _date.Value.ToString(Format) : "";
                ForeColor = IsToday ? TodayForeColor : ForeColor;
            }
        }
    
        public bool IsToday
        {
            get  {
                if (!_date.HasValue)
                    return false;    
                return _date.Value.Date == DateTime.Today;
            }
        }
    
        public string Format { get; set; }
        public Color TodayForeColor { get; set; }
    }
