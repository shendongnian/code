     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();
            Students.Add(new Student() { Name = "Aeqwwe", Age = 24 });
            Students.Add(new Student() { Name = "bqwewqeq", Age = 28 });
            Students.Add(new Student() { Name = "cwqeqw", Age = 23 });
            Students.Add(new Student() { Name = "dweqqw", Age = 29 });
            Students.Add(new Student() { Name = "eqweweq", Age = 20 });
            DataContext = this;
        }
        public ObservableCollection<Student> Students { get; set; }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var items = value as ObservableCollection<Student>;
            if (parameter != null && items != null)
            {
                if (parameter.ToString() == "agelessthan25")
                {
                    return items.Where(i => i.Age < 25).ToList();
                }
                else if (parameter.ToString() == "agegreaterthan25")
                {
                    return items.Where(i => i.Age >= 25).ToList();
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
