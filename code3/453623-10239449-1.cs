    public Form1()
      {
        InitializeComponent();
        for(int i = 0; i < 10; i++) {
            comboBox1.Items.Add(String.Format("Item {0}", i.ToString()));
        }
        comboBox1.SelectedIndex = 0;
      }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
      {
        comboBox2.Items.Clear();
        for (int i = 0; i < 5; i++)
        {
          comboBox2.Items.Add(String.Format("Item_{0}_{1}", 
                              comboBox1.SelectedItem, i.ToString()));
        }
        comboBox2.SelectedIndex = 0;
      }
