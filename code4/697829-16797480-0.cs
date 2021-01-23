    public class CsvDataRow : INotifyPropertyChanged
    {
        private bool _aa;
        private string _course;
        private int _semester;
        private double _theory;
        private double _lab;
        private bool _passed;
        public bool AA { get { return _aa; } set { if (value == _aa) return; _aa = value; NotifyPropertyChanged("AA"); } }
        public string Course { get { return _course; } set { if (value == _course) return; _course = value; NotifyPropertyChanged("Course"); } }
        public int Semester { get { return _semester; } set { if (value == _semester) return; _semester = value; NotifyPropertyChanged("Semester"); } }
        public double Theory { get { return _theory; } set { if (value == _theory) return; _theory = value; NotifyPropertyChanged("Theory"); } }
        public double Lab { get { return _lab; } set { if (value == _lab) return; _lab = value; NotifyPropertyChanged("Lab"); } }
        public bool Passed { get { return _passed; } set { if (value == _passed) return; _passed = value; NotifyPropertyChanged("Passed"); } }
        char _delimiter;
        
        // static factory method creates object from CSV row
        public static CsvDataRow Create(string row, char delimiter)
        {
            return new CsvDataRow(row, delimiter);
        }
        // private constructor initializes property values
        private CsvDataRow(string row, char delimiter)
        {
            _delimiter = delimiter;
            var values = row.Split(_delimiter);
            AA = (values[0].ToString().Equals("1"));
            Course = Convert.ToString(values[1]);
            Semester = Convert.ToInt32(values[2]);
            Theory = Convert.ToDouble(values[3]);
            Lab = Convert.ToDouble(values[4]);
            Passed = (values[5].ToString().Equals("1"));
        }
        // a method to convert back into a CSV row
        public string ToCsvString()
        {
            var values = new string[] { (AA ? 1 : 0).ToString(), Course, Semester.ToString(), Theory.ToString(), Lab.ToString(), (Passed ? 1: 0).ToString() };
            return string.Join(_delimiter.ToString(), values);
        }
        // INotifyPropertyChanged interface requires this event
        public event PropertyChangedEventHandler PropertyChanged;
        // helper method to raise PropertyChanged event
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
