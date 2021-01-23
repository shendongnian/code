    class MainWindowViewModel : PropertyChangedBase
    {
       ObservableCollection<Student> _Students = new ObservableCollection<Student>();
       public ObservableCollection<Student> Students
       {
          get { return _Students; }
       }
    public MainWindowViewModel()
    {
      _Students.Add(new Student() { StudentFirstName = "Foo", StudentLastName = "Bar" });
      _Students.Add(new Student() { StudentFirstName = "John", StudentLastName = "Doe" });
      _Students.Add(new Student() { StudentFirstName = "Emy", StudentLastName = "Bob" });
    }
