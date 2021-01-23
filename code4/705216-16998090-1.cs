      public Form1()
        {
            InitializeComponent();
    
            comboBox1.DataSource = b1;
            comboBox2.DataSource = b2;
    
            Boolean lDoing1;
            Boolean lDoing2;
        }
    
       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lDoing1)
            {
             Return;
            }
            if (b2.Remove((string) comboBox1.SelectedItem))
            {
                lDoing2 = True ; 
                b2.Remove((string) comboBox1.SelectedItem);
                lDoing2 = False ;
            }
            if (!b1.Contains((string) comboBox2.SelectedItem))
            {
                b1.Add((string) comboBox2.SelectedItem);
            }
        }
    
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lDoing2)
            {
             Return;
            }
            if (b1.Remove((string)comboBox2.SelectedItem))
            {
                lDoing1 = True ;
                b1.Remove((string)comboBox2.SelectedItem);
                lDoing1 = False ;
            }
            if (!b2.Contains((string)comboBox1.SelectedItem))
            {
                b2.Add((string)comboBox1.SelectedItem);
            }
        }
