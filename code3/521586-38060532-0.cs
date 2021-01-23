    bool go = false; //for changing cell color
        int count = 10; //to stop timer (blinking)
        public blinkForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Thread a = new Thread(blink);
            a.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Columns.Count == 0)
            {
                //generate new columns for DataGridView
                dataGridView1.Columns.Add("user", "User");
                dataGridView1.Columns.Add("pcStatus", "PC Status");
                dataGridView1.Columns.Add("service", "Servis");
                //generate new rows for DataGridView
                dataGridView1.Rows.Add("Ali", "PC007", "chrome.exe");
                dataGridView1.Rows.Add("Vusal", "PC010", "photoshop.exe");
                dataGridView1.Rows.Add("Rahim", "PC015", "chrome.exe");
            }
        }
        private void blink(object o)
        {
            while (count > 0)
            {
                while (!go)
                {
                    //change color for binking
                    dataGridView1.Rows[0].Cells["service"].Style.BackColor = Color.Tomato;
                    go = true;
                    //stop for 0.5 second
                    Thread.Sleep(500);
                }
                while (go)
                {
                    //change color for binking
                    dataGridView1.Rows[0].Cells["service"].Style.BackColor = Color.LimeGreen;
                    go = false;
                    //stop for 0.5 second
                    Thread.Sleep(500);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            count--;
            if (count == 0)
            {
                //stop blinking after 10 second
                timer1.Stop();
            }
        }
