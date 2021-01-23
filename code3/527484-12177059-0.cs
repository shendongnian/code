     public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.SelectedIndex = 0;
            comboBox1.Focus();
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (comboBox1.SelectedIndex != 0)
                    comboBox1.SelectedIndex--;
            }
            if (e.Key == Key.Down)
            {
                if (comboBox1.SelectedIndex != comboBox1.Items.Count-1)
                    comboBox1.SelectedIndex++;
            }
                
        }
    }
