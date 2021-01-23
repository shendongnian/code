    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            StudentModel = new students();
        }
        private students _studentModel;
        public students StudentModel
        { 
            get { return _studentModel; }
            set { _studentModel = value; NotifyPropertyChanged("StudentModel"); }
        }
        private GetStudents_Result _selectedResult;
        public GetStudents_Result SelectedResult 
        {
            get { return _selectedResult; }
            set { _selectedResult = value; NotifyPropertyChanged("SelectedResult"); }
        }
     
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            StudentModel.std.Remove(SelectedResult);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
    public class students
    {
        public students()
        {
            std = new ObservableCollection<GetStudents_Result>();
            for (int i = 0; i < 100; i++)
            {
                std.Add(new GetStudents_Result { Fname = "FirstName" + i, Lname = "LasrName" + i });
            }
        }
        public ObservableCollection<GetStudents_Result> std { get; set; }
    }
    public class GetStudents_Result : INotifyPropertyChanged
    {
        private string _fname;
        private string _lname;
        public string Fname
        {
            get { return _fname; }
            set { _fname = value; NotifyPropertyChanged("Fname"); }
        }
        public string Lname
        {
            get { return _lname; }
            set { _lname = value; NotifyPropertyChanged("Lname"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
