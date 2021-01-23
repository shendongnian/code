    System.Windows.Forms.Timer t;
            public Form1()
            {
                InitializeComponent();
               
                t = new System.Windows.Forms.Timer();
                t.Interval = SystemInformation.DoubleClickTime - 1;
                t.Tick += new EventHandler(t_Tick);
            }
    
            void t_Tick(object sender, EventArgs e)
            {
                t.Stop();
                DataGridViewCellEventArgs dgvcea = (DataGridViewCellEventArgs)t.Tag;
                MessageBox.Show("Single");
                //do whatever you do in single click
            }
    
            private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
            {
                t.Tag = e;
                t.Start();
            }
    
            private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                t.Stop();
                MessageBox.Show("Double");
                //do whatever you do in double click
            }
