    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            // set the DataContext to the code in this window
            this.DataContext = this;
            // create youe Student model
            StudentModel = new students();
        }
        // Create a public property of your student Model
        private students _studentModel;
        public students StudentModel
        { 
            get { return _studentModel; }
            set { _studentModel = value; NotifyPropertyChanged("StudentModel"); }
        }
        // create a public property to use as the selected item from your models "std" collection
        private GetStudents_Result _selectedResult;
        public GetStudents_Result SelectedResult 
        {
            get { return _selectedResult; }
            set { _selectedResult = value; NotifyPropertyChanged("SelectedResult"); }
        }
        
     
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // if you want to remove an item you just have to remove it from
            // the model, the INotifyPropertyChanged interface will notify the UI
            // to update, no need to call Refresh, same works for Add etc
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
