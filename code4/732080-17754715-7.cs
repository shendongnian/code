    public partial class MyWindow : UserControl {
        public MyWindow() {
            InitializeComponent();
            MyListBox.ItemsSource = new List<Person> {
                new Person("Sam", "Smith"),
                new Person("Jim", "Henson"),
                new Person("Betty", "White"),
            };
        }
