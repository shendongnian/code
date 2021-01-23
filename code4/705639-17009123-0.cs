        private void Form1_Load(object sender, EventArgs e)
        {
            Timer t1 = new Timer();
            t1.Interval = 50;
            t1.Tick += new EventHandler(timer1_Tick);
            t1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = Cursor.Position.X.ToString();
            textBox2.Text = Cursor.Position.Y.ToString();
        }
