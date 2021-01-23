     public Form1()
            {
                InitializeComponent();
            }
    
            TimeSpan t1 = new TimeSpan(0, 11, 0);
            TimeSpan t2 = new TimeSpan(0, 16, 30);
    
            private void button1_Click(object sender, EventArgs e)
            {
            	TimeSpan dif = t2 - t1;
                label1.Text = dif.ToString();
            }
