    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var comboBoxItem1 = new ComboBoxItem();
            var comboBoxItem2 = new ComboBoxItem();
    
            comboBoxItem1.Content = "111111";
            comboBoxItem1.GotFocus += (sender, args) => lbl1.Content = "1111";
            comboBoxItem2.Content = "222222";
            comboBoxItem2.GotFocus += (sender, args) => lbl1.Content = "2222";
            
            comboBox1.Items.Add(comboBoxItem1);
            comboBox1.Items.Add(comboBoxItem2);
        }
    }
