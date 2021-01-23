        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Item One");                        //Index 0
            comboBox1.Items.Add("Item Two");                        //Index 1
            comboBox1.Items.Add("Item Three");                             //Index 2
            comboBox1.Items.Add("Item Four");                       //Index 3
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Tag != null && (int)comboBox1.Tag == comboBox1.SelectedIndex)
                return;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    comboBox1.Tag = comboBox1.SelectedIndex;
                    comboBox1.Items[comboBox1.SelectedIndex] = "changed item 2";
                    break;
                case 2:
                    comboBox1.Tag = comboBox1.SelectedIndex;
                    comboBox1.Items[comboBox1.SelectedIndex] = "changed item 3";
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
