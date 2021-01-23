        public partial class MainWindow : Window
            {
                private ObservableCollection<person> _people;
        
                public ObservableCollection<person> people
                {
                    get { return _people; }
                    set { _people = value; }
                }
                public MainWindow()
                {
    InitializeComponent();
                    people = new ObservableCollection<person>();
                }
               public class person
                {
                    public string STT { get; set; }
                    public string HVT { get; set; }
                    public string Age { get; set; }
                    public string State { get; set; }
                }
                
                public void button1_Click(object sender, RoutedEventArgs e)
                {           
                    people.Add(new person() { STT = textBox1.Text.ToString(), HVT = textBox2.Text.ToString(), Age = textBox3.Text.ToString(), State = textBox4.Text.ToString() });
                    this.listView1.ItemsSource = people;
                }
        
            }
