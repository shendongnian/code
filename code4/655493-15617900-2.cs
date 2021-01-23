    public ObservableCollection<Model> ModelListe { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            comboBox1.Items.Add("Test1");
            comboBox1.Items.Add("Test2");
            comboBox1.Items.Add("Test3");
            comboBox1.Items.Add("Test4");
            comboBox1.Items.Add("Test5");
            
            ModelListe = new ObservableCollection<Model>();
            DataContext = this;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox1.SelectedItem != null)
                {
                    Model model = new Model();
                    model.Component = comboBox1.SelectedItem.ToString();
                    model.Question = textBox1.Text;
                    ModelListe.Add(model);
                }
            }
        }
    public class Model
    {
        public string Component { get; set; }
        public string Question { get; set; }
    }
