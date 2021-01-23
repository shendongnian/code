    public class ViewModel
    {
        private DataRow _model;
        private string _dateField;
    
        public ViewModel(DataRow row, string dateField)
        {
            _model = row;
            _dateField = dateField;
        }
    
        public string MyRowID
        {
            get { return _model.Field<string>("MyRowID"); }
            set { _model["MyRowID"] = value; }
        }
    
        public string Type { get; set; }
    
        public DateTime ScheduleDate
        {
            get { return _model.Field<DateTime>(_dateField); }
            set { _model[_dateField] = value; }
        }
    }
