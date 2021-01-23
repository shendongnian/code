        public Form1()
        {
            InitializeComponent();
            ctlPickButton1.pickButtonClicked += new EventHandler(ctlPickButton1_pickButtonClicked);
            ctlPickButton2.pickButtonClicked += new EventHandler(ctlPickButton2_pickButtonClicked);
        }
        void ctlPickButton2_pickButtonClicked(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                MessageBox.Show(comboBox2.SelectedItem.ToString());
            }
        }
        void ctlPickButton1_pickButtonClicked(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                MessageBox.Show(comboBox1.SelectedItem.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("French");
            comboBox1.Items.Add("Spanish");
            comboBox1.Items.Add("English");
            comboBox1.Items.Add("German");
            comboBox2.Items.Add("Pizza");
            comboBox2.Items.Add("Hamburger");
            comboBox2.Items.Add("Potato");
            comboBox2.Items.Add("Chicken");
            //Shows how the default image set in the designer can be overwritten for a 
            //specific instance using the "Image" property
            ctlPickButton2.Image = Testbed.Properties.Resources.searchIcon2;
        }
    }
