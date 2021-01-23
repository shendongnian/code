        public Form1()
        {
            InitializeComponent();
        }
    
        private void Button1Click(object sender, EventArgs e)
        {
            string _yourName = textBox1.Text;
            if (DogCheckBox.Checked)
            {
                AnimalNoise.Bark(_yourName);
            }
    
            if (CatCheckBox.Checked)
            {
                AnimalNoise.Meow(_yourName);
            }
    
            if (FishCheckBox.Checked)
            {
                AnimalNoise.Girgle(_yourName);
            }
        }
    }
