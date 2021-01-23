    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <ListBox ItemsSource="{Binding Students}" DisplayMemberPath="Name" SelectedItem="{Binding SelectedStudent, Mode=TwoWay}"/>
        <StackPanel Grid.Column="1">
            <TextBlock Text="{Binding SelectedStudent.FamilyName}"/>
            <TextBlock Text="{Binding SelectedStudent.PhoneNumber}"/>
        </StackPanel>
    </Grid>
        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Students = new ObservableCollection<Student>();
            Students.Add(new Student()
            {
                Name = "James",
                FamilyName = "mangol",
                PhoneNumber = "01234 111111"
            });
            Students.Add(new Student()
            {
                Name = "Bob",
                FamilyName = "angol",
                PhoneNumber = "01234 222222"
            });
            Students.Add(new Student()
            {
                Name = "Emma",
                FamilyName = "pangol",
                PhoneNumber = "01234 333333"
            });
        }
        public ObservableCollection<Student> Students { get; set; }
        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set { selectedStudent = value; Notify("SelectedStudent"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    
    }
    public class Student:INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; Notify("Name"); }
        }
        private string familyname;
        public string FamilyName
        {
            get { return familyname; }
            set { familyname = value;Notify("FamilyName"); }
        }
        private string phonenumber;
        public string PhoneNumber
        {
            get { return phonenumber; }
            set { phonenumber = value; Notify("PhoneNumber"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
